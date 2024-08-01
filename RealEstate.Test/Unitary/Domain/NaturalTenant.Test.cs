using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Test.Unitary.DataAttributes.NaturalTenantDto;
using RealEstate.Test.Unitary.DataAttributes.PersonDto;

namespace RealEstate.Test.Unitary.Domain;

public class NaturalTenantUnitaryTests
{
    private readonly Person representant = Person.FromDto(
        CreatePersonDtoDataAttribute_Valid.PersonDtoWithAddressComplement()
    );

    [Theory]
    [CreateNaturalTenantDtoTestDataAttribute_Valid]
    public void ShouldMapNaturalTenant(CreateNaturalTenantDto dto)
    {
        NaturalTenant naturalTenant = NaturalTenant.FromDto(dto);

        Assert.Equal(naturalTenant.Person.Address?.Street, dto.Person.Address.Street);
        Assert.Equal(naturalTenant.Person.Address?.Number, dto.Person.Address.Number);
        Assert.Equal(naturalTenant.Person.Address?.Neighborhood, dto.Person.Address.Neighborhood);
        Assert.Equal(naturalTenant.Person.Address?.City, dto.Person.Address.City);
        Assert.Equal(naturalTenant.Person.Address?.PostalCode, dto.Person.Address.PostalCode);
        Assert.Equal(naturalTenant.Person.Address?.State, dto.Person.Address.State);
        Assert.Equal(naturalTenant.Person.Address?.Country, dto.Person.Address.Country);
        Assert.Equal(naturalTenant.Person.Email, dto.Person.Email);
        Assert.Equal(naturalTenant.Person.Name, dto.Person.Name);
        Assert.Equal(naturalTenant.Person.Phone, dto.Person.Phone);
        Assert.Equal(naturalTenant.Person.Address?.Street, dto.Person.Address.Street);
        Assert.Equal(naturalTenant.Person.Address?.Number, dto.Person.Address.Number);
        Assert.Equal(naturalTenant.Person.Address?.Neighborhood, dto.Person.Address.Neighborhood);
        Assert.Equal(naturalTenant.Person.Address?.City, dto.Person.Address.City);
        Assert.Equal(naturalTenant.Person.Address?.PostalCode, dto.Person.Address.PostalCode);
        Assert.Equal(naturalTenant.Person.Address?.State, dto.Person.Address.State);
        Assert.Equal(naturalTenant.Person.Address?.Country, dto.Person.Address.Country);
        Assert.Equal(naturalTenant.Person.Email, dto.Person.Email);
        Assert.Equal(naturalTenant.Person.Name, dto.Person.Name);
        Assert.Equal(naturalTenant.Person.Phone, dto.Person.Phone);
        Assert.NotNull(naturalTenant?.StartDate);
        Assert.True(naturalTenant?.IsActive);
        Assert.Empty(naturalTenant?.Documents ?? []);
        Assert.Empty(naturalTenant?.Notes ?? []);
    }

    [Fact]
    public void ShouldUpdateNaturalTenantFromDto()
    {
        CreateNaturalTenantDto createDto =
            CreateNaturalTenantDtoTestDataAttribute_Valid.CreateNaturalTenantBaseDto();

        NaturalTenant naturalTenant = NaturalTenant.FromDto(createDto);
        Document document =
            new()
            {
                CreationDate = DateTime.Now,
                Id = 1,
                OwnerId = 1,
                OwnerType = EDocumentOwnerType.Tenant,
                Path = "www.somepath.net",
                Type = EDocumentType.Cpf
            };
        UpdateNaturalTenantDto updateDto =
            new()
            {
                Id = 1,
                Notes = ["First Note"],
                Documents = [document],
                IsActive = false,
                Person = new() { Name = "new Name" },
            };

        naturalTenant.UpdateFromDto(updateDto);

        Assert.Equal(naturalTenant?.Person.Name, updateDto.Person.Name);
        Assert.NotEmpty(naturalTenant?.Documents ?? []);
        Assert.Contains(document, naturalTenant?.Documents ?? []);
        Assert.NotEmpty(naturalTenant?.Notes ?? []);
        Assert.Contains("First Note", naturalTenant?.Notes ?? []);
        Assert.False(naturalTenant?.IsActive);

        Assert.Equal(naturalTenant?.Person.Address?.Street, createDto.Person.Address.Street);
        Assert.Equal(naturalTenant?.Person.Address?.Number, createDto.Person.Address.Number);
        Assert.Equal(
            naturalTenant?.Person.Address?.Neighborhood,
            createDto.Person.Address.Neighborhood
        );
        Assert.Equal(naturalTenant?.Person.Address?.City, createDto.Person.Address.City);
        Assert.Equal(
            naturalTenant?.Person.Address?.PostalCode,
            createDto.Person.Address.PostalCode
        );
        Assert.Equal(naturalTenant?.Person.Address?.State, createDto.Person.Address.State);
        Assert.Equal(naturalTenant?.Person.Address?.Country, createDto.Person.Address.Country);
        Assert.Equal(naturalTenant?.Person.Email, createDto.Person.Email);
        Assert.Equal(naturalTenant?.Person.Phone, createDto.Person.Phone);
        Assert.Equal(naturalTenant?.Person.Address?.Street, createDto.Person.Address.Street);
        Assert.Equal(naturalTenant?.Person.Address?.Number, createDto.Person.Address.Number);
        Assert.Equal(
            naturalTenant?.Person.Address?.Neighborhood,
            createDto.Person.Address.Neighborhood
        );
        Assert.Equal(naturalTenant?.Person.Address?.City, createDto.Person.Address.City);
        Assert.Equal(
            naturalTenant?.Person.Address?.PostalCode,
            createDto.Person.Address.PostalCode
        );
        Assert.Equal(naturalTenant?.Person.Address?.State, createDto.Person.Address.State);
        Assert.Equal(naturalTenant?.Person.Address?.Country, createDto.Person.Address.Country);
        Assert.Equal(naturalTenant?.Person.Email, createDto.Person.Email);
        Assert.Equal(naturalTenant?.Person.Phone, createDto.Person.Phone);
        Assert.NotNull(naturalTenant?.StartDate);
    }
}
