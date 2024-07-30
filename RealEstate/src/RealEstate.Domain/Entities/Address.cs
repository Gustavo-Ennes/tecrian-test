using RealEstate.Api.Dtos;
using RealEstate.Utils;

namespace RealEstate.Domain.Entities;

public class Address
{
    public int? Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string? Complement { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public static Address FromDto(AddressCreateDto dto) =>
        new()
        {
            Street = dto.Street,
            Number = dto.Number,
            Complement = dto.Complement,
            Neighborhood = dto.Neighborhood,
            City = dto.City,
            State = dto.State,
            PostalCode = dto.PostalCode,
            Country = dto.Country ?? "Brasil"
        };

    public Address UpdateFromDto(AddressUpdateDto dto)
    {
        Street = dto.Street ?? Street;
        Number = dto.Number ?? Number;
        Complement = dto.Complement ?? Complement;
        Neighborhood = dto.Neighborhood ?? Neighborhood;
        City = dto.City ?? City;
        State = dto.State ?? State;
        PostalCode = dto.PostalCode ?? PostalCode;
        Country = dto.Country ?? Country;

        return this;
    }


    public override string ToString() => 
        this.SerializeIndented();
}
