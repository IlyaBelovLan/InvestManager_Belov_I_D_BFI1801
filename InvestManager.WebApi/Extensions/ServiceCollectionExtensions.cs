namespace InvestManager.WebApi.Extensions
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Методы расширений для <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавляет указанного типа из конфигурации.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <typeparam name="TSetting">Тип настройки.</typeparam>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAppSetting<TSetting>(this IServiceCollection services, IConfiguration configuration) where TSetting : class
        {
            var setting = configuration.GetSection(typeof(TSetting).Name).Get<TSetting>(); 
            services.AddSingleton(setting);
            return services;
        }
        
        /// <summary>
        /// Добавляет Swagger.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        internal static IServiceCollection AddSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme { Reference = new OpenApiReference { Type=ReferenceType.SecurityScheme, Id = "Bearer" } },
                        Array.Empty<string>()
                    }
                });
                
                options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1",  Title = "WebAPI менеджера инвестиций" });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "InvestManager.WebAPI.xml"));
            });
    }
}