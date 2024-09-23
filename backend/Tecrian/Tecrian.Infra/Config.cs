using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tecrian.Domain.Entities;
using Tecrian.Infra.Database;
using Tecrian.Infra.Database.Repository;
using Tecrian.Infra.Email;
using Tecrian.Infra.Profiles;

namespace Tecrian.Infra;

public static class ConfigInfrastructureExtension
{
    public static void ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<TecrianDbContext>(options =>
            options.UseSqlServer(
                configuration["sqlConnection"],
                sqlOptions => sqlOptions.MigrationsAssembly("Tecrian.Api")
            )
        );

        services.AddScoped<IRepository<User>, UserRepository>();
        services.AddScoped<IEmailSender, EmailSender>();

        services.ConfigureAutoMapperProfiles();
    }

    public static void ConfigureAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(TecrianMapProfile));
    }
}
