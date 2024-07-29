#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace RealEstate.Api.Dtos;

public class CreateCompanyDto
{
    public string Email { get; set; }
    public string Cnpj { get; set; }
    public string Phone { get; set; }
    public string Name { get; set; }
    public AddressCreateDto Address { get; set; }
    public CreatePersonDto Representant { get; set; }
}

public class UpdateCompanyDto
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Cnpj { get; set; }
    public string? Phone { get; set; }
    public string? Name { get; set; }
    public AddressUpdateDto? Address { get; set; }
    public UpdatePersonDto? Representant { get; set; }
}
