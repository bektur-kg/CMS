using CMS.Application.Abstractions.Authentication;
using CMS.Application.Abstractions.Data;
using CMS.Application.Features.DoctorProfiles;
using CMS.Application.Features.MedicalCards;
using CMS.Application.Features.Qualifications;
using CMS.Application.Features.Users;
using CMS.Infrastructure.DbContexts;
using CMS.Infrastructure.Modules.DoctorProfiles;
using CMS.Infrastructure.Modules.MedicalCards;
using CMS.Infrastructure.Modules.Qualifications;
using CMS.Infrastructure.Modules.Users;
using CMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(nameof(AppDbContext));

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddTransient<IPasswordManager, PasswordManager>();
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddTransient<IUserContext, UserContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDoctorProfileRepository, DoctorProfileRepository>();
        services.AddScoped<IMedicalCardRepository, MedicalCardRepository>();
        services.AddScoped<IQualificationRepository, QualificationRepository>();

        return services;
    }
}
