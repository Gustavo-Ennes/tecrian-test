using System.Text.Json.Serialization;
using RealEstate.Shared.Utils;

namespace RealEstate.Domain.Entities;

public class LegalTenant : TenantBase
{
    [JsonIgnore]
    public Company Company { get; set; } = null!;
    public int CompanyId { get; set; }

    public LegalTenant() { }

    public override string ToString() => this.SerializeIndented();
}
