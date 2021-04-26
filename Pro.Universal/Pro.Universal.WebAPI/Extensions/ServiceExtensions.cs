using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pro.Universal.Common.Services;
using Pro.Universal.Common.Services.Interfaces;
using Pro.Universal.Data.DbContext;
using Pro.Universal.Data.Repositories;
using Pro.Universal.Data.Repositories.Interfaces;
using Pro.Universal.WebAPI.ActionFilters;

namespace Pro.Universal.WebAPI.Extensions
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

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProUniversalContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("proConnection")));
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }   
    }
}