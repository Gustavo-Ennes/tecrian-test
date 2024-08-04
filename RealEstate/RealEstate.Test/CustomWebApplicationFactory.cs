using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstate.Infra.Database;

namespace RealEstate.Test;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>
    where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        builder.ConfigureServices(services =>
        {
            var context = services.FirstOrDefault(descriptor =>
                descriptor.ServiceType == typeof(RealEstateDbContext)
            );
            if (context != null)
            {
                services.Remove(context);
                var options = services
                    .Where(r =>
                        r.ServiceType == typeof(DbContextOptions)
                        || r.ServiceType.IsGenericType
                            && r.ServiceType.GetGenericTypeDefinition()
                                == typeof(DbContextOptions<>)
                    )
                    .ToArray();
                foreach (var option in options)
                {
                    services.Remove(option);
                }
            }

            services.AddDbContext<RealEstateDbContext>(options =>
            {
                options.UseInMemoryDatabase("RealEstateInMemory");
            });
        });
    }
}
