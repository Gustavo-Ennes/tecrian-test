namespace RealEstate.Domain.Entities;

public class TenantBase
{
    public int? Id { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public List<string> Notes { get; set; } = [];
    public List<int> DocumentIds { get; set; } = [];

    public TenantBase() { }

    public void Disable()
    {
        IsActive = false;
        EndDate = DateTime.Now;
    }
}
