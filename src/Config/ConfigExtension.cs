using Microsoft.EntityFrameworkCore;
using RealEstate.App.Services;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database;
using RealEstate.Infra.Repositories;

namespace RealEstate.Config;

public static class ConfigExtension
{
    public static void ConfigureServices(
        this IServiceCollection services,
        IConfigurationRoot configuration
    )
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration["sqlConnection"])
        );

        services.AddScoped<IRepository<Tenant>, Repository<Tenant>>();
        services.AddScoped<ITenantService, TenantService>();
        services.AddControllers();
    }
}
