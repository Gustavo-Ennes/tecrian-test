using RealEstate.Domain.Entities;
using RealEstate.Infra.Database.Repository;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;

namespace RealEstate.Test.Integration.Base;

public class LegalTenantTests(CustomWebApplicationFactory<Program> factory)
    : BaseIntegration(factory)
{
    [Fact]
    public async Task AddLegalTenant()
    {
        // Arrange
        await using var context = await CreateInMemoryDbContext();
        var legalTenantRepository = new Repository<LegalTenant>(context);
        var addressRepository = new Repository<Address>(context);
        var personRepository = new Repository<Person>(context);
        var companyRepository = new Repository<Company>(context);

        var autoMapperAddress = _mapper.Map<Address>(CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement());
        Console.WriteLine($"autoMapperAddress: {autoMapperAddress}");

        var address = new Address()
        {
            Street = "Rua Augusta",
            Number = "11",
            Neighborhood = "Vila Olímpia",
            City = "São Paulo",
            Country = "Brasil",
            PostalCode = "15987654",
            State = "São Paulo"
        };
        var representant = new Person()
        {
            AddressId = 1,
            Email = "person@email.com",
            Name = "Jhon Doe",
            Phone = "3216549877"
        };
        var company = new Company()
        {
            AddressId = 1,
            Email = "person@email.com",
            Name = "Comapny x",
            Phone = "98765432154",
            Cnpj = "12312312312323",
            RepresentantId = 1
        };
        var legalTenant = new LegalTenant() { CompanyId = 1 };

        // Act - Add
        await addressRepository.AddAsync(address);
        var addedAddress = await addressRepository.GetByIdAsync(1);
        Console.WriteLine($"addedAddress: {addedAddress}");
        await personRepository.AddAsync(representant);
        await companyRepository.AddAsync(company);
        await legalTenantRepository.AddAsync(legalTenant);

        // Assert - Add
        Assert.NotNull(addedAddress);
        Assert.Equal(address.Street, addedAddress.Street);
        Assert.Equal(address.Neighborhood, addedAddress.Neighborhood);

        // Act - Remove
        if (addedAddress.Id != null)
        {
            await addressRepository.DeleteAsync((int)addedAddress.Id);
            var removedUser = await addressRepository.GetByIdAsync((int)addedAddress.Id);
            Assert.Null(removedUser);
        }
    }
}
