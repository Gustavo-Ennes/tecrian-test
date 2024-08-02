using RealEstate.App;

namespace RealEstate.Api.ConfigExtensions;

public static class ConfigExtension
{
    public static void ConfigureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.ConfigureApplicationServices(configuration);
        services.AddControllers();
    }
}
