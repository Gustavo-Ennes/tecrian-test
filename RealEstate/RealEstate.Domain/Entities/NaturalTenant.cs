using System.Text.Json.Serialization;
using RealEstate.Shared.Utils;

namespace RealEstate.Domain.Entities;

public class NaturalTenant : TenantBase
{
    [JsonIgnore]
    public Person Person { get; set; } = null!;
    public int PersonId { get; set; }

    public NaturalTenant() { }

    public override string ToString() => this.SerializeIndented();
}
