using RealEstate.Shared.Dtos.Base;

namespace RealEstate.Shared.Dtos;

public class CreateNaturalTenantDto : CreateBaseDto
{
    public int PersonId { get; set; }
}

public class UpdateNaturalTenantDto : UpdateTenantDto
{
    public int? PersonId { get; set; }
}
