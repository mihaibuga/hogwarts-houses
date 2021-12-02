using HogwartsPotions.DAL;
using HogwartsPotions.DAL.Interfaces;
using HogwartsPotions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HogwartsPotions.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection ConfigureCors(
            this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            return services;
        }

        public static IServiceCollection ConfigureControllers(
            this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(option =>
                    option.SerializerSettings
                    .ReferenceLoopHandling = Newtonsoft
                    .Json.ReferenceLoopHandling.Ignore
                )
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.Converters
                    .Add(new Newtonsoft.Json.
                        Converters.StringEnumConverter()
                    )
                );

            return services;
        }

        public static IServiceCollection ConfigureDbContext(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HogwartsContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection ConfigureInternalDependencies(
            this IServiceCollection services)
        {
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IPotionRepository, PotionRepository>();
            services.AddScoped<IPotionService, PotionService>();
            services.AddScoped<IRoomService, RoomService>();

            return services;
        }
    }
}
