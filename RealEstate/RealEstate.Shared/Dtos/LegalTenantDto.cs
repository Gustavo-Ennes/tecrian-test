using RealEstate.Shared.Dtos.Base;

namespace RealEstate.Shared.Dtos;

public class CreateLegalTenantDto : CreateBaseDto
{
    public int CompanyId { get; set; }
}

public class UpdateLegalTenantDto : UpdateTenantDto
{
    public int? CompanyId { get; set; }
}
