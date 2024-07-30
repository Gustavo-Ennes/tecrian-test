

using RealEstate.App;
using RealEstate.Infra;

namespace RealEstate.ConfigExtension;

public static class ConfigExtension
{
    public static void ConfigureServices(
        this IServiceCollection services,
        IConfigurationRoot configuration
    )
    {
        services.ConfigureApplicationServices();
        services.ConfigureInfrastructureServices(configuration);
        
        services.AddControllers();
    }
}
