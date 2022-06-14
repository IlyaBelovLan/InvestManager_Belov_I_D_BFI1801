namespace InvestManager.WebApi
{
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Common.Authorization.AccessToken;
    using Common.Authorization.AccessToken.Factory;
    using Common.Context.UserContext;
    using Database.Configuration;
    using Database.Context;
    using Extensions;
    using FinancialData.UseCases.GetCurrentPrice;
    using FluentValidation;
    using Infrastructure.Authorization;
    using Infrastructure.ExceptionHandling;
    using Infrastructure.RequestValidator;
    using Infrastructure.UserContext;
    using MediatR;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TwelveData.Client.Configuration;
    using TwelveData.Client.Factory;
    using Users.UseCases.Users.RegisterUser;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            
            services
                .AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)));
            
            services.AddControllers(options => options.Filters.Add(new ExceptionHandler()));
            
            services.AddSwagger();
            
            services
                .AddAppSetting<TwelveDataConnectConfiguration>(Configuration)
                .AddAppSetting<DatabaseConfiguration>(Configuration)
                .AddAppSetting<JwtTokenConfiguration>(Configuration);
            
            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
            var jwtTokenConfiguration = Configuration.GetSection(nameof(JwtTokenConfiguration)).Get<JwtTokenConfiguration>();
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = AuthorizationParameters.GetTokenValidationParameters(jwtTokenConfiguration.SigningKey));
            services.AddTransient<IAccessTokensFactory, JwtTokensFactory>();

            services
                .AddTransient<ITwelveDataClientFactory, TwelveDataClientFactory>()
                .AddTransient(s => s.GetRequiredService<ITwelveDataClientFactory>().Create());

            var assemblies = new[]
            {
                typeof(GetCurrentPriceUseCase).Assembly,
                typeof(RegisterUserUseCase).Assembly,
                typeof(RequestValidator<>).Assembly,
                typeof(SetUserContextPipelineBehavior<,>).Assembly
            };
            services.AddMediatR(assemblies);
            services.AddAutoMapper(assemblies);
            services.AddValidatorsFromAssemblies(assemblies);
            
            var databaseConfiguration = Configuration.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();
            services.AddDbContext<DatabaseContext>(options => options
                .UseSqlServer(
                    databaseConfiguration.ConnectionString,
                    sqlSeverOptions => sqlSeverOptions.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));

            services.AddTransient<IUserContextProvider, UserContextProvider>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SetUserContextPipelineBehavior<,>));
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("default");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InvestManager.WebApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}