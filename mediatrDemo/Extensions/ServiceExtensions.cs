﻿using mediatrDemo.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace mediatrDemo
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });
        }
    }
}