using Tecrian.Shared.Utils;

namespace Tecrian.Domain.Entities;

public class User
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsEmailVerified { get; set; }

    public User() { }

    public override string ToString() => this.SerializeIndented();
}
