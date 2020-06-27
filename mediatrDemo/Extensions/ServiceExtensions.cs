using mediatrDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;



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

        public static void ConfigureValues(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<Settings>(options =>
            {
                options.MongoDBConnectionString = Configuration.GetSection("DBConnections:MongoConnectionString").Value;
                options.SqlServerConnectionString = Configuration.GetSection("DBConnections:SqlServerConnectionString").Value;
                options.NotesDatabase = Configuration.GetSection("DBConnections:NoteDataBase").Value;
                options.EmployeeDatabase = Configuration.GetSection("DBConnections:EmployeeDatabase").Value;
                options.Env = Configuration.GetSection("Enviroment:Value").Value;
               
            });
        }
       
        public static void AddDBContext<T>(this IServiceCollection services, IConfiguration Configuration) where T : DbContext
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(Configuration.GetSection("DBConnections:SqlServerConnectionString").Value,
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                });
            });
        }
    }
}