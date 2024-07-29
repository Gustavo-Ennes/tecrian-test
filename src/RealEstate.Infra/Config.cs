using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database;
using RealEstate.Infra.Database.Repository;

namespace RealEstate.Infra;

public static class ConfigInfrastructureExtension
{
    public static void ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfigurationRoot configuration
    )
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration["sqlConnection"])
        );

        services.AddScoped<IRepository<LegalTenant>, Repository<LegalTenant>>();
        services.AddScoped<IRepository<NaturalTenant>, Repository<NaturalTenant>>();
        services.AddScoped<IRepository<Address>, Repository<Address>>();
        services.AddScoped<IRepository<Company>, Repository<Company>>();
        services.AddScoped<IRepository<Person>, Repository<Person>>();
        services.AddScoped<IRepository<Document>, Repository<Document>>();
    }
}
