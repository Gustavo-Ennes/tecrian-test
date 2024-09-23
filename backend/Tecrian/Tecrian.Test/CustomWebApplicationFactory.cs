using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tecrian.Infra.Database;
using Tecrian.Infra.Email;

namespace Tecrian.Test;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram>
    where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        builder.ConfigureServices(services =>
        {
            var context = services.FirstOrDefault(descriptor =>
                descriptor.ServiceType == typeof(TecrianDbContext)
            );
            var emailSender = services.FirstOrDefault(descriptor =>
                descriptor.ServiceType == typeof(IEmailSender)
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
            if (emailSender != null)
            {
                services.Remove(emailSender);
                var options = services
                    .Where(r =>
                        r.ServiceType == typeof(IEmailSender)
                    )
                    .ToArray();
                foreach (var option in options)
                {
                    services.Remove(option);
                }
            }

            services.AddDbContext<TecrianDbContext>(options =>
            {
                options.UseInMemoryDatabase("TecrianInMemory");
            });
            services.AddSingleton<IEmailSender, FakeEmailSender>();
        });
    }

}
