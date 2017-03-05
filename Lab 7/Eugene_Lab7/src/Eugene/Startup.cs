using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Eugene.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Eugene.Models;

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
            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddMvc();
            
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //    name: "default",
            //    template: "{controller=Message}/{action=List}/{id?}");
                
            //});
            app.UseMvcWithDefaultRoute();

            SeedData.EnsurePopulated(app);
        }
    }
}
