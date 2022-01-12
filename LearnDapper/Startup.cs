using LearnDapper.Business.Services;
using LearnDapper.DAL;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Reflection;
using System.Web.Mvc;

namespace LearnDapper
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped(p => new DbConnectionFactory(Configuration));

            services.AddScoped<IDbConnection>(provider => provider
                .GetRequiredService<DbConnectionFactory>()
                .GetConnection());

            services.AddScoped<UserService>();

            services.AddMvc(opt => opt.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
         
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default", 
                    template: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            });

            app.UseRouting();
        }
    }
}
