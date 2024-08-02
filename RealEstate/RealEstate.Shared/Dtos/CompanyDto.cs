using RealEstate.Shared.Dtos.Base;

namespace RealEstate.Shared.Dtos;

public class CreateCompanyDto : CreateBaseDto
{
    public string Email { get; set; } = null!;
    public string Cnpj { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int AddressId { get; set; }
    public int RepresentantId { get; set; }
}

public class UpdateCompanyDto : UpdateBaseDto
{
    public string? Email { get; set; }
    public string? Cnpj { get; set; }
    public string? Phone { get; set; }
    public string? Name { get; set; }
    public int? AddressId { get; set; }
    public int? RepresentantId { get; set; }
}
