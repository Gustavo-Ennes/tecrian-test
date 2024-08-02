using System.Text.Json.Serialization;
using RealEstate.Shared.Utils;

namespace RealEstate.Domain.Entities;

public class Company
{
    public int? Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    [JsonIgnore]
    public Address Address { get; set; } = null!;
    public int AddressId { get; set; }

    [JsonIgnore]
    public Person Representant { get; set; } = null!;
    public int RepresentantId { get; set; }

    public Company() { }

    public override string ToString() => this.SerializeIndented();
}
