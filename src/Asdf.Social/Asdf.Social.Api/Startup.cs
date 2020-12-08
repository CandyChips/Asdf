using Akka.Actor;
using Asdf.Social.Api.Commands;
using Asdf.Social.Services.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IApplicationLifetime = Microsoft.AspNetCore.Hosting.IApplicationLifetime;

namespace Asdf.Social.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("AsdfSocialDB")));
            
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyHeader());
            });
            
            services.AddScoped<IDataAccelerator, EntityFrameworkAccelerator>();
            
            services.AddSingleton(provider =>
            {
                var serviceScopeFactory = provider.GetService<IServiceScopeFactory>();
                var actorSystem = ActorSystem.Create("AsdfSocialActorSystem", ConfigurationLoader.Load());
                actorSystem.AddServiceScopeFactory(serviceScopeFactory);
                return actorSystem;
            });
            
            services.AddSingleton<CreateSocialProfileActorProvider>(provider =>
            {
                var actorSystem = provider.GetService<ActorSystem>();
                var booksManagerActor = actorSystem.ActorOf(Props.Create(() => new CreateSocialProfileActor()));
                return () => booksManagerActor;
            });
            
            services.AddSwaggerGen();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env, 
            IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseCors("CorsPolicy");
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
            
            lifetime.ApplicationStarted.Register(() =>
            {
                app.ApplicationServices.GetService<ActorSystem>(); // start Akka.NET
            });
            
            lifetime.ApplicationStopping.Register(() =>
            {
                app.ApplicationServices.GetService<ActorSystem>().Terminate().Wait();
            });
        }
    }
}
