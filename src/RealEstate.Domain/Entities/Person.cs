using RealEstate.Api.Dtos;

namespace RealEstate.Domain.Entities;

public class Person
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public Address? Address { get; set; }

    public Person() { }

    public static Person FromDto(CreatePersonDto dto) =>
        new()
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
            Address = Address.FromDto(dto.Address)
        };

    public Person UpdateFromDto(UpdatePersonDto dto)
    {
        Name = dto.Name ?? Name;
        Email = dto.Email ?? Email;
        Phone = dto.Phone ?? Phone;

        if (dto.Address != null)
            Address = Address?.UpdateFromDto(dto.Address);

        return this;
    }
}
