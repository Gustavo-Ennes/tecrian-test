using System.Text.Json.Serialization;
using RealEstate.Shared.Utils;

namespace RealEstate.Domain.Entities;

public class Person
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    [JsonIgnore]
    public Address? Address { get; set; }
    public int AddressId { get; set; }

    public Person() { }

    public override string ToString() => this.SerializeIndented();
}
