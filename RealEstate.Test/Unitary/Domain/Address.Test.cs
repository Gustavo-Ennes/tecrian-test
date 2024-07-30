using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;
using RealEstate.Test.Unitary.Domain.DataAttributes;

namespace RealEstate.Test.Unitary.Domain;

public class AddressUnitaryTests
{
    [Theory]
    [AddressDtoTestData]
    public void ShouldMapAddress(AddressCreateDto dto)
    {
        Address address = Address.FromDto(dto);

        Assert.Equal(address.Street, dto.Street);
        Assert.Equal(address.Number, dto.Number);
        Assert.Equal(address.Neighborhood, dto.Neighborhood);
        Assert.Equal(address.City, dto.City);
        Assert.Equal(address.PostalCode, dto.PostalCode);
        Assert.Equal(address.State, dto.State);
        Assert.Equal(address.Country, dto.Country);
    }

    [Fact]
    public void ShouldUpdateAddressFromDto()
    {
        AddressCreateDto createDto = AddressDtoTestDataAttribute.GetAddressWithComplement();

        Address address = Address.FromDto(createDto);
        AddressUpdateDto updateDto = new() { Id = 1, Street = "Rua 13" };

        address.UpdateFromDto(updateDto);

        Assert.Equal(address.Street, updateDto.Street);

        Assert.Equal(address.Number, createDto.Number);
        Assert.Equal(address.Neighborhood, createDto.Neighborhood);
        Assert.Equal(address.City, createDto.City);
        Assert.Equal(address.PostalCode, createDto.PostalCode);
        Assert.Equal(address.State, createDto.State);
        Assert.Equal(address.Country, createDto.Country);
    }
}
