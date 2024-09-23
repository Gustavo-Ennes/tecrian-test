using AutoMapper;
using Tecrian.Infra.Profiles;

namespace Tecrian.Test.Integration.Base;

public class BaseIntegration(CustomWebApplicationFactory<Program> factory)
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    public CustomWebApplicationFactory<Program> _factory = factory;
    public readonly HttpClient _client = factory.CreateClient();
    public readonly IMapper _mapper = AddAutoMapper();

    public static IMapper AddAutoMapper()
    {
        MapperConfiguration mapperConfig =
            new(cfg =>
            {
                cfg.AddProfile(new TecrianMapProfile());
            });

        IMapper mapper = new Mapper(mapperConfig);
        mapper.ConfigurationProvider.AssertConfigurationIsValid();
        return mapper;
    }
}
