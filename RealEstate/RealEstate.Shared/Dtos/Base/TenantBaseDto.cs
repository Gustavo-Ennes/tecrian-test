namespace RealEstate.Shared.Dtos.Base;

public class UpdateTenantDto : UpdateBaseDto
{
    public DateTime? EndDate { get; set; }
    public bool? IsActive { get; set; }
    public List<string>? Notes { get; set; } = null!;
    public List<int>? DocumentIds { get; set; }
}
