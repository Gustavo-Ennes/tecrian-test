#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

using RealEstate.Api.Dtos.Base;

namespace RealEstate.Api.Dtos;

public class CreateLegalTenantDto : CreateTenantDto
{
    public CreateCompanyDto Company { get; set; }
    public int RepresentantId { get; set; }
}

public class UpdateLegalTenantDto : UpdateTenantDto
{
    public UpdateCompanyDto? Company { get; set; }
    public int? RepresentantId { get; set; }
}
