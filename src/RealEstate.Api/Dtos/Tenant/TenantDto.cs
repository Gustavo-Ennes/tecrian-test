namespace RealEstate.Api.Dtos.Tenant;

public class UpdateTenantDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool? IsActive { get; set; }
    public List<string>? Notes { get; set; }
}

public class CreateTenantDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
}
