using Serilog;
using Tecrian.App;

namespace Tecrian.Api.ConfigExtensions;

public static class ConfigExtension
{
    public static void ConfigureServices(
        this WebApplicationBuilder builder,
        IConfiguration configuration
    )
    {
        IServiceCollection services = builder.Services;

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.ConfigureApplicationServices(configuration);
        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost4200",
                policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        services.AddControllers();

        builder.Configuration.AddUserSecrets<Program>();

        ConfigureSerilog(builder);
    }

    public static void ConfigureSerilog(WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}
