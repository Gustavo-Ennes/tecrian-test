using RealEstate.Api.Dtos.Tenant;

namespace RealEstate.Domain.Entities;

public class Tenant
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public List<string> Notes { get; set; } = [];

    public Tenant() { }

    public void Disable()
    {
        IsActive = false;
        EndDate = DateTime.Now;
    }

    public static Tenant FromDto(CreateTenantDto dto) =>
        new()
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone
        };

    public static Tenant UpdateFromDto(Tenant tenant, UpdateTenantDto dto)
    {
        tenant.Name = dto.Name ?? tenant.Name;
        tenant.Email = dto.Email ?? tenant.Email;
        tenant.Phone = dto.Phone ?? tenant.Phone;
        tenant.IsActive = dto.IsActive ?? tenant.IsActive;
        tenant.Notes = dto.Notes ?? tenant.Notes;

        return tenant;
    }
}
