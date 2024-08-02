using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database;
using RealEstate.Infra.Database.Repository;
using RealEstate.Shared.Dtos;
using RealEstate.Shared.Profiles;

namespace RealEstate.Infra;

public static class ConfigInfrastructureExtension
{
    public static void ConfigureInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
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

        services.ConfigureAutoMapperProfiles();
    }

    public static void ConfigureAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BaseProfile<Address, CreateAddressDto>));
        services.AddAutoMapper(typeof(BaseProfile<Person, CreatePersonDto>));
        services.AddAutoMapper(typeof(BaseProfile<Company, CreateCompanyDto>));
        services.AddAutoMapper(typeof(BaseProfile<LegalTenant, CreateLegalTenantDto>));
        services.AddAutoMapper(typeof(BaseProfile<NaturalTenant, CreateNaturalTenantDto>));
    }
}
