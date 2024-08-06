using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Infra.Database;
using RealEstate.Infra.Profiles;

namespace RealEstate.Test.Integration.Base;

public class BaseIntegration(CustomWebApplicationFactory<Program> factory)
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    protected readonly HttpClient _client = factory.CreateClient();
    protected readonly IMapper _mapper = AddAutoMapper();

    protected DbContextOptions<RealEstateDbContext> CreateInMemoryDbContextOptions()
    {
        return new DbContextOptionsBuilder<RealEstateDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;
    }

    protected async Task<RealEstateDbContext> CreateInMemoryDbContext()
    {
        var options = CreateInMemoryDbContextOptions();
        var context = new RealEstateDbContext(options);
        await context.Database.OpenConnectionAsync();
        await context.Database.EnsureCreatedAsync();
        return context;
    }

    private static IMapper AddAutoMapper()
    {
        MapperConfiguration mapperConfig =
            new(cfg =>
            {
                cfg.AddProfile(new RealEstateMapProfile());
            });

        IMapper mapper = new Mapper(mapperConfig);
        mapper.ConfigurationProvider.AssertConfigurationIsValid();
        return mapper;
    }
}
