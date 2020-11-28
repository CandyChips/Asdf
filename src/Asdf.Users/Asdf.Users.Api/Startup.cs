using System;
using System.Net.NetworkInformation;
using System.Reflection;
using Asdf.UserDomain.Services.Mappers;
using Asdf.UserDomain.Services.Requests.Behaviours;
using Asdf.Users.Models.Entities;
using Asdf.Users.Services.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Asdf.Users.Services.Repositories.Interfaces;
using Asdf.Users.Services.Repositories.EntityFramework;
using Asdf.Users.Services.Requests.Queries;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Asdf.Users.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("AsdfUsersDB")));
            
            services.AddSwaggerGen();
            
            services.AddControllers();
            
            services.AddLogging();
            
            services.AddScoped<IDataAccelerator, EntityFrameworkAccelerator>();
            
            services.AddTransient<IUserRepository, UserRepository>();
            
            var assembly = AppDomain.CurrentDomain.Load("Asdf.Users.Services");
            services.AddMediatR(assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();    
            app.UseSwaggerUI(c => 
            { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nano35 service API");
            });

        }
    }
}