using RealEstate.App.Services;

namespace RealEstate.App;

public static class ConfigExtension
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<INaturalTenantService, NaturalTenantService>();
        services.AddScoped<ILegalTenantService, LegalTenantService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<ICompanyService, CompanyService>();
    }
}
