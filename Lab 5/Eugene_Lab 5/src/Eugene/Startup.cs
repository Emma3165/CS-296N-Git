using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Eugene.Repositories;
using Microsoft.Extensions.Configuration;
using Eugene.Models;
using Microsoft.EntityFrameworkCore;

namespace Eugene
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:Eugene:ConnectionString"]));
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute(
                name: "default",
                template: "{controller=Message}/{action=List}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
