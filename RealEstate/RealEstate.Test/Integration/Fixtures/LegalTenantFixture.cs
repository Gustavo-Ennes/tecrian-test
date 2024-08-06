using RealEstate.Domain.Entities;
using RealEstate.Infra.Database;
using RealEstate.Shared.Dtos;
using RealEstate.Test.Integration.Base;
using RealEstate.Test.Unitary.DataAttributes.AddressDto;
using RealEstate.Test.Unitary.DataAttributes.CompanyDto;
using RealEstate.Test.Unitary.DataAttributes.LegalTenantDto;
using RealEstate.Test.Unitary.DataAttributes.PersonDto;
using RealEstate.Test.Unitary.Validation.LegalTenantDto;

namespace RealEstate.Test.Integration.Fixtures;

[Collection("LegalTenant")]
public class LegalTenantFixture : BaseFixture, IFixture
{
    public async Task AddData()
    {
        // var address = new Address()
        // {
        //     Street = "Rua Augusta",
        //     Number = "11",
        //     Neighborhood = "Vila Olímpia",
        //     City = "São Paulo",
        //     Country = "Brasil",
        //     PostalCode = "15987654",
        //     State = "São Paulo"
        // };
        Address address = _mapper.Map<Address>(
            CreateAddressDtoDataAttribute_Valid.GetAddressWithComplement()
        );
        // var representant = new Person()
        // {
        //     AddressId = 1,
        //     Email = "person@email.com",
        //     Name = "Jhon Doe",
        //     Phone = "3216549877"
        // };
        Person representant = _mapper.Map<Person>(CreatePersonDtoDataAttribute_Valid.Person1());
        // var company = new Company()
        // {
        //     AddressId = 1,
        //     Email = "person@email.com",
        //     Name = "Comapny x",
        //     Phone = "98765432154",
        //     Cnpj = "12312312312323",
        //     RepresentantId = 1
        // };
        Company company = _mapper.Map<Company>(CreateCompanyDtoDataAttribute_Valid.Company1());
        // var legalTenant = new LegalTenant() { CompanyId = 1 };
        LegalTenant legalTenant= _mapper.Map<LegalTenant>(CreateLegalTenantDtoDataAttribute_Valid.CreateLegalTenantBaseDto());

        // Act - Add
        await _addressRepository.AddAsync(address);
        var addedAddress = await _addressRepository.GetByIdAsync(1);
        Console.WriteLine($"addedAddress: {addedAddress}");
        await _personRepository.AddAsync(representant);
        await _companyRepository.AddAsync(company);
        await _legalTenantRepository.AddAsync(legalTenant);
    }
}

[CollectionDefinition("LegalTenant")]
public class DatabaseCollection : ICollectionFixture<LegalTenantFixture> { }
