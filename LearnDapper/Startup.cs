using LearnDapper.DAL.Repositories;
using LearnDapper.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LearnDapper
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=userstore;Trusted_Connection=True;";

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserRepository, UserRepository>(provider => new UserRepository(connectionString));
            
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
