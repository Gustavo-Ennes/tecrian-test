using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;
using RealEstate.Test.Unitary.Domain.DataAttributes;

namespace RealEstate.Test.Unitary.Domain;

public class CompanyUnitaryTests
{
    private readonly Person representant = Person.FromDto(
        PersonDtoTestDataAttribute.PersonDtoWithAddressComplement()
    );
    
    [Theory]
    [CompanyDtoTestData]
    public void ShouldMapCompany(CreateCompanyDto dto)
    {
        Company company = Company.FromDto(dto, representant);

        Assert.Equal(company.Address?.Street, dto.Address.Street);
        Assert.Equal(company.Address?.Number, dto.Address.Number);
        Assert.Equal(company.Address?.Neighborhood, dto.Address.Neighborhood);
        Assert.Equal(company.Address?.City, dto.Address.City);
        Assert.Equal(company.Address?.PostalCode, dto.Address.PostalCode);
        Assert.Equal(company.Address?.State, dto.Address.State);
        Assert.Equal(company.Address?.Country, dto.Address.Country);
        Assert.Equal(company.Email, dto.Email);
        Assert.Equal(company.Name, dto.Name);
        Assert.Equal(company.Phone, dto.Phone);
        Assert.Equal(company.Representant.Address?.Street, dto.Address.Street);
        Assert.Equal(company.Representant.Address?.Number, dto.Representant.Address.Number);
        Assert.Equal(
            company.Representant.Address?.Neighborhood,
            dto.Representant.Address.Neighborhood
        );
        Assert.Equal(company.Representant.Address?.City, dto.Representant.Address.City);
        Assert.Equal(company.Representant.Address?.PostalCode, dto.Representant.Address.PostalCode);
        Assert.Equal(company.Representant.Address?.State, dto.Representant.Address.State);
        Assert.Equal(company.Representant.Address?.Country, dto.Representant.Address.Country);
        Assert.Equal(company.Representant.Email, dto.Representant.Email);
        Assert.Equal(company.Representant.Name, dto.Representant.Name);
        Assert.Equal(company.Representant.Phone, dto.Representant.Phone);
    }

    [Fact]
    public void ShouldUpdateCompanyFromDto()
    {
        CreateCompanyDto createDto = CompanyDtoTestDataAttribute.CompanyDtoWithAddressComplement();
        Company company = Company.FromDto(createDto, representant);

        UpdateCompanyDto updateDto =
            new()
            {
                Id = 1,
                Name = "Nova Era",
                Address = new AddressUpdateDto() { State = "Rio Grande do Norte" },
                Representant = new UpdatePersonDto() { Email = "nova@era.com" }
            };
        company.UpdateFromDto(updateDto);

        Assert.Equal(company.Address?.State, updateDto.Address.State);
        Assert.Equal(company.Representant.Email, updateDto.Representant.Email);
        Assert.Equal(company.Name, updateDto.Name);

        Assert.Equal(company.Address?.Neighborhood, createDto.Address.Neighborhood);
        Assert.Equal(company.Address?.City, createDto.Address.City);
        Assert.Equal(company.Address?.PostalCode, createDto.Address.PostalCode);
        Assert.Equal(company.Address?.Country, createDto.Address.Country);
        Assert.Equal(company.Email, createDto.Email);
        Assert.Equal(company.Phone, createDto.Phone);
        Assert.Equal(company.Representant.Address?.Street, createDto.Address.Street);
        Assert.Equal(company.Representant.Address?.Number, createDto.Representant.Address.Number);
        Assert.Equal(
            company.Representant.Address?.Neighborhood,
            createDto.Representant.Address.Neighborhood
        );
        Assert.Equal(company.Representant.Address?.City, createDto.Representant.Address.City);
        Assert.Equal(
            company.Representant.Address?.PostalCode,
            createDto.Representant.Address.PostalCode
        );
        Assert.Equal(company.Representant.Address?.State, createDto.Representant.Address.State);
        Assert.Equal(company.Representant.Address?.Country, createDto.Representant.Address.Country);
        Assert.Equal(company.Representant.Name, createDto.Representant.Name);
        Assert.Equal(company.Representant.Phone, createDto.Representant.Phone);
    }
}
