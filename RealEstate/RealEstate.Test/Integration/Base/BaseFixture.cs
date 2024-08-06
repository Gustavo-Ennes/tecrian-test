using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;
using RealEstate.Infra.Database;
using RealEstate.Infra.Database.Repository;
using RealEstate.Infra.Profiles;

namespace RealEstate.Test.Integration.Base;

public class BaseFixture : IDisposable
{
    public RealEstateDbContext _context;
    public Repository<LegalTenant> _legalTenantRepository;
    public Repository<Address> _addressRepository;
    public Repository<NaturalTenant> _naturalTenantRepository;
    public Repository<Company> _companyRepository;
    public Repository<Person> _personRepository;
    public readonly IMapper _mapper = AddAutoMapper();

    public BaseFixture()
    {
        _context = CreateInMemoryDbContext();
        _legalTenantRepository = new(_context);
        _naturalTenantRepository = new(_context);
        _personRepository = new(_context);
        _companyRepository = new(_context);
        _addressRepository = new(_context);
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

    public static DbContextOptions<RealEstateDbContext> CreateInMemoryDbContextOptions()
    {
        return new DbContextOptionsBuilder<RealEstateDbContext>()
            .UseSqlite("DataSource=:memory:")
            .Options;
    }

    public static RealEstateDbContext CreateInMemoryDbContext()
    {
        var options = CreateInMemoryDbContextOptions();
        var context = new RealEstateDbContext(options);
        context.Database.OpenConnection();
        context.Database.EnsureCreated();
        return context;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
