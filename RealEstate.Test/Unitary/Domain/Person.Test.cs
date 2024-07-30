using RealEstate.Api.Dtos;
using RealEstate.Domain.Entities;
using RealEstate.Test.Unitary.Domain.DataAttributes;

namespace RealEstate.Test.Unitary.Domain;

public class PersonUnitaryTests
{
    [Theory]
    [PersonDtoTestData]
    public void ShouldMapPerson(CreatePersonDto dto)
    {
        Person person = Person.FromDto(dto);

        Assert.Equal(person.Address?.Street, dto.Address.Street);
        Assert.Equal(person.Address?.Number, dto.Address.Number);
        Assert.Equal(person.Address?.Neighborhood, dto.Address.Neighborhood);
        Assert.Equal(person.Address?.City, dto.Address.City);
        Assert.Equal(person.Address?.PostalCode, dto.Address.PostalCode);
        Assert.Equal(person.Address?.State, dto.Address.State);
        Assert.Equal(person.Address?.Country, dto.Address.Country);
        Assert.Equal(person.Email, dto.Email);
        Assert.Equal(person.Name, dto.Name);
        Assert.Equal(person.Phone, dto.Phone);
    }

    [Fact]
    public void ShouldUpdatePersonFromDto()
    {
        CreatePersonDto createDto = PersonDtoTestDataAttribute.PersonDtoWithAddressComplement();

        Person person = Person.FromDto(createDto);
        UpdatePersonDto updateDto = new() { Id = 1, Name = "Gustavo Augusto" };

        person.UpdateFromDto(updateDto);

        Assert.Equal(person.Name, updateDto.Name);

        Assert.Equal(person.Phone, createDto.Phone);
        Assert.Equal(person.Address?.Street, createDto.Address.Street);
        Assert.Equal(person.Address?.Number, createDto.Address.Number);
        Assert.Equal(person.Address?.Neighborhood, createDto.Address.Neighborhood);
        Assert.Equal(person.Address?.City, createDto.Address.City);
        Assert.Equal(person.Address?.PostalCode, createDto.Address.PostalCode);
        Assert.Equal(person.Address?.State, createDto.Address.State);
        Assert.Equal(person.Address?.Country, createDto.Address.Country);
        Assert.Equal(person.Email, createDto.Email);
    }
}
