using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Asdf.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration) { Configuration = configuration; }
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services) 
        { 
            services.AddOcelot(Configuration);
            services.AddSwaggerForOcelot(Configuration);
        }

        public async void Configure(IApplicationBuilder app)
        {
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });
            await app.UseOcelot();
        }
    }
}
