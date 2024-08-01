using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;
using RealEstate.Domain.Enums;
using RealEstate.Test.Unitary.DataAttributes.LegalTenantDto;
using RealEstate.Test.Unitary.DataAttributes.PersonDto;

namespace RealEstate.Test.Unitary.Domain;

public class LegalTenantUnitaryTests
{
    private readonly Person representant = Person.FromDto(
        CreatePersonDtoDataAttribute_Valid.PersonDtoWithAddressComplement()
    );

    [Theory]
    [CreateLegalTenantDtoDataAttribute_Valid]
    public void ShouldMapLegalTenant(CreateLegalTenantDto dto)
    {
        LegalTenant legalTenant = LegalTenant.FromDto(dto, representant);

        Assert.Equal(legalTenant.Company.Address?.Street, dto.Company.Address.Street);
        Assert.Equal(legalTenant.Company.Address?.Number, dto.Company.Address.Number);
        Assert.Equal(legalTenant.Company.Address?.Neighborhood, dto.Company.Address.Neighborhood);
        Assert.Equal(legalTenant.Company.Address?.City, dto.Company.Address.City);
        Assert.Equal(legalTenant.Company.Address?.PostalCode, dto.Company.Address.PostalCode);
        Assert.Equal(legalTenant.Company.Address?.State, dto.Company.Address.State);
        Assert.Equal(legalTenant.Company.Address?.Country, dto.Company.Address.Country);
        Assert.Equal(legalTenant.Company.Email, dto.Company.Email);
        Assert.Equal(legalTenant.Company.Name, dto.Company.Name);
        Assert.Equal(legalTenant.Company.Phone, dto.Company.Phone);
        Assert.Equal(
            legalTenant.Company.Representant.Address?.Street,
            dto.Company.Representant.Address.Street
        );
        Assert.Equal(
            legalTenant.Company.Representant.Address?.Number,
            dto.Company.Representant.Address.Number
        );
        Assert.Equal(
            legalTenant.Company.Representant.Address?.Neighborhood,
            dto.Company.Representant.Address.Neighborhood
        );
        Assert.Equal(
            legalTenant.Company.Representant.Address?.City,
            dto.Company.Representant.Address.City
        );
        Assert.Equal(
            legalTenant.Company.Representant.Address?.PostalCode,
            dto.Company.Representant.Address.PostalCode
        );
        Assert.Equal(
            legalTenant.Company.Representant.Address?.State,
            dto.Company.Representant.Address.State
        );
        Assert.Equal(
            legalTenant.Company.Representant.Address?.Country,
            dto.Company.Representant.Address.Country
        );
        Assert.Equal(legalTenant.Company.Representant.Email, dto.Company.Representant.Email);
        Assert.Equal(legalTenant.Company.Representant.Name, dto.Company.Representant.Name);
        Assert.Equal(legalTenant.Company.Representant.Phone, dto.Company.Representant.Phone);
        Assert.NotNull(legalTenant?.StartDate);
        Assert.True(legalTenant?.IsActive);
        Assert.Empty(legalTenant?.Documents ?? []);
        Assert.Empty(legalTenant?.Notes ?? []);
    }

    [Fact]
    public void ShouldUpdateLegalTenantFromDto()
    {
        CreateLegalTenantDto createDto =
            CreateLegalTenantDtoDataAttribute_Valid.CreateLegalTenantBaseDto();

        LegalTenant legalTenant = LegalTenant.FromDto(createDto, representant);
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
        UpdateLegalTenantDto updateDto =
            new()
            {
                Id = 1,
                Notes = ["First Note"],
                Documents = [document],
                IsActive = false,
                Company = new() { Name = "new Name" },
            };

        legalTenant.UpdateFromDto(updateDto);

        Assert.NotEmpty(legalTenant?.Documents ?? []);
        Assert.Contains(document, legalTenant?.Documents ?? []);
        Assert.NotEmpty(legalTenant?.Notes ?? []);
        Assert.Contains("First Note", legalTenant?.Notes ?? []);
        Assert.False(legalTenant?.IsActive);

        Assert.Equal(legalTenant?.Company.Address?.Street, createDto.Company.Address.Street);
        Assert.Equal(legalTenant?.Company.Address?.Number, createDto.Company.Address.Number);
        Assert.Equal(
            legalTenant?.Company.Address?.Neighborhood,
            createDto.Company.Address.Neighborhood
        );
        Assert.Equal(legalTenant?.Company.Address?.City, createDto.Company.Address.City);
        Assert.Equal(
            legalTenant?.Company.Address?.PostalCode,
            createDto.Company.Address.PostalCode
        );
        Assert.Equal(legalTenant?.Company.Address?.State, createDto.Company.Address.State);
        Assert.Equal(legalTenant?.Company.Address?.Country, createDto.Company.Address.Country);
        Assert.Equal(legalTenant?.Company.Email, createDto.Company.Email);
        Assert.Equal(legalTenant?.Company.Phone, createDto.Company.Phone);
        Assert.Equal(
            legalTenant?.Company.Representant.Address?.Street,
            createDto.Company.Representant.Address.Street
        );
        Assert.Equal(
            legalTenant?.Company.Representant.Address?.Number,
            createDto.Company.Representant.Address.Number
        );
        Assert.Equal(
            legalTenant?.Company.Representant.Address?.Neighborhood,
            createDto.Company.Representant.Address.Neighborhood
        );
        Assert.Equal(
            legalTenant?.Company.Representant.Address?.City,
            createDto.Company.Representant.Address.City
        );
        Assert.Equal(
            legalTenant?.Company.Representant.Address?.PostalCode,
            createDto.Company.Representant.Address.PostalCode
        );
        Assert.Equal(
            legalTenant?.Company.Representant.Address?.State,
            createDto.Company.Representant.Address.State
        );
        Assert.Equal(
            legalTenant?.Company.Representant.Address?.Country,
            createDto.Company.Representant.Address.Country
        );
        Assert.Equal(legalTenant?.Company.Representant.Email, createDto.Company.Representant.Email);
        Assert.Equal(legalTenant?.Company.Representant.Name, createDto.Company.Representant.Name);
        Assert.Equal(legalTenant?.Company.Representant.Phone, createDto.Company.Representant.Phone);
        Assert.NotNull(legalTenant?.StartDate);
    }
}
