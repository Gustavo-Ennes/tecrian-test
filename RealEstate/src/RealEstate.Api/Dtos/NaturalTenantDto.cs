#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

using RealEstate.Api.Dtos.Base;

namespace RealEstate.Api.Dtos;

public class CreateNaturalTenantDto : CreateTenantDto
{
    public CreatePersonDto Person { get; set; }
}

public class UpdateNaturalTenantDto : UpdateTenantDto
{
    public UpdatePersonDto? Person { get; set; }
}
