using System.Reflection;
using HealthChecks.UI.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mediatrDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IMediatorService, MediatorService>();
            services.AddHealthChecks();
            services.AddHealthChecks().AddSqlServer(Configuration["DBConnections:SqlServerConnectionString"]);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHealthChecks("/hc");

            app.UseHealthChecksUI(delegate (Options options)
            {
                options.UIPath = "/hc-ui";
                
            });

            app.UseStaticFiles();

            app.UseRouting();

        }
    }
}