using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.App.Services;
using RealEstate.Infra;

namespace RealEstate.App;

public static class ConfigExtension
{
    public static void ConfigureApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<INaturalTenantService, NaturalTenantService>();
        services.AddScoped<ILegalTenantService, LegalTenantService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<ICompanyService, CompanyService>();

        services.ConfigureInfrastructureServices(configuration);
    }
}
