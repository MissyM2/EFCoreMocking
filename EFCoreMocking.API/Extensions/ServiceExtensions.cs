using System;
using EFCoreMocking.API.Contracts;
using EFCoreMocking.API.Data;
using EFCoreMocking.API.Repositories;
using EFCoreMocking.API.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMocking.API.Extensions
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
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration config)
        {
            //var connectionString = config["mysqlconnection:connectionString"];
            var connString = "Filename=:memory:";

            //services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString,
            //MySqlServerVersion.LatestSupportedServerVersion));

            var conn = new SqliteConnection(connString);
            conn.Open();
            services.AddDbContext<EmployeeDbContext>(opt => opt.UseSqlite(conn));


            //builder.Services.AddDbContext<EmployeeDBContext>(options =>
            //    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString") ?? throw new InvalidOperationException("Connection string 'EmployeeDBContext' not found.")));


        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}

