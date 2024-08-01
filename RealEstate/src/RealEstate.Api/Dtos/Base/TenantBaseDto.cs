#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

using RealEstate.Domain.Entities;

namespace RealEstate.Api.Dtos.Base;

public class CreateTenantDto
{
    public CreateAddressDto Address { get; set; }
}

public class UpdateTenantDto : UpdateBaseDto
{
    public DateTime? EndDate { get; set; }
    public bool? IsActive { get; set; }
    public List<string>? Notes { get; set; }
    public List<Document>? Documents { get; set; }
    public UpdateAddressDto? Address { get; set; }
}
