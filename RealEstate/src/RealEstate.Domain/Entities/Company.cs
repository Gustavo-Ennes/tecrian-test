using RealEstate.Api.Dtos;
using RealEstate.Utils;

namespace RealEstate.Domain.Entities;

public class Company
{
    public int? Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public required Address Address { get; set; }
    public required Person Representant { get; set; }

    public static Company FromDto(CreateCompanyDto dto, Person representant) =>
        new()
        {
            Email = dto.Email,
            Cnpj = dto.Cnpj,
            Phone = dto.Phone,
            Name = dto.Name,
            Address = Address.FromDto(dto.Address),
            Representant = representant
        };

    public Company UpdateFromDto(UpdateCompanyDto dto)
    {
        Email = dto.Email ?? Email;
        Cnpj = dto.Cnpj ?? Cnpj;
        Phone = dto.Phone ?? Phone;
        Name = dto.Name ?? Name;

        if (dto.Address != null)
            Address = Address.UpdateFromDto(dto.Address);
        if (dto.Representant != null)
            Representant = Representant.UpdateFromDto(dto.Representant);

        return this;
    }


    public override string ToString() => 
        this.SerializeIndented();
}
