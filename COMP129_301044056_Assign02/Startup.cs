using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using COMP229_301044056_Assign02.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace COMP229_301044056_Assign02
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
        Configuration = configuration;

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // create a data base connection later
            //services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(
            //        Configuration["Data:SaucePotRecipes:ConnectionString"]));
            services.AddTransient<IRecipeRepository, FakeRecipeRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                name: "pagination",
                template: "Recipes/Page{recipePage}",
                defaults: new { Controller = "Recipe", action = "List" });
                routes.MapRoute(
                name: "default",
                template: "{controller=Recipe}/{action=List}/{id?}");
            });
        }
    }
}
