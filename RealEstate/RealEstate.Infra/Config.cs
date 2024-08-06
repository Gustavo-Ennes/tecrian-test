using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database;
using RealEstate.Infra.Database.Repository;
using RealEstate.Infra.Profiles;

namespace RealEstate.Infra;

public static class ConfigInfrastructureExtension
{
    public static void ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<RealEstateDbContext>(options =>
            options.UseSqlServer(
                configuration["sqlConnection"],
                sqlOptions => sqlOptions.MigrationsAssembly("RealEstate.Api")
            )
        );

        services.AddScoped<IRepository<LegalTenant>, Repository<LegalTenant>>();
        services.AddScoped<IRepository<NaturalTenant>, Repository<NaturalTenant>>();
        services.AddScoped<IRepository<Address>, Repository<Address>>();
        services.AddScoped<IRepository<Company>, Repository<Company>>();
        services.AddScoped<IRepository<Person>, Repository<Person>>();
        services.AddScoped<IRepository<Document>, Repository<Document>>();

        services.ConfigureAutoMapperProfiles();
    }

    public static void ConfigureAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(RealEstateMapProfile));
    }
}
