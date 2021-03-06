﻿using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Reflection;

namespace mediatrDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILogger<Startup> logger, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
        }        
       

        public IConfiguration Configuration { get; }
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment webHostEnvironment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("ConfigureServices");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IDataService, DataService>();
            services.ConfigureCors();           
            services.AddSwaggerGen();
            services.AddOpenTelemetryTracing(
             builder =>
             {
                 _logger.LogInformation("AddOpenTelemetryTracing");
                 builder
                     .SetResourceBuilder(ResourceBuilder
                         .CreateDefault()
                         .AddService(webHostEnvironment.ApplicationName))
                     .AddAspNetCoreInstrumentation();
                 if (webHostEnvironment.IsDevelopment())
                 {
                     builder.AddConsoleExporter(options => options.Targets = ConsoleExporterOutputTargets.Debug);
                 }
             });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _logger.LogInformation("ApplicationName" + env.ApplicationName);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}