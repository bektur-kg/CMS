using CMS.Api.OptionsSetup;
using CMS.Application;
using CMS.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CMS.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddApplication();
        services.AddWebApi();

        return services;
    }

    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.AddAuthorizationBuilder()
            .AddPolicy("Doctor", policy => policy.RequireRole("Doctor"))
            .AddPolicy("Patient", policy => policy.RequireRole("Patient"));

        services.AddHttpContextAccessor();
        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();

        return services;
    }
}
