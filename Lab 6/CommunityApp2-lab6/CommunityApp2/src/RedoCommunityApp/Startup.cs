using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RedoCommunityApp.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using RedoCommunityApp.Models;

namespace RedoCommunityApp
{
    public class Startup
    {
        private IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                    options.UseSqlServer(
                        Configuration["Data:RedoCommunityApp:ConnectionString"])
            );
            services.AddMvc();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvcWithDefaultRoute();
            SeedData.EnsurePopulated(app);
        }
    }
}
