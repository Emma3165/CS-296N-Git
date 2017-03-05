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


namespace Eugene
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
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
        }
    }
}
