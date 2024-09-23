namespace Tecrian.Shared.Dtos;

public class CreateUserDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
}

public class UpdateUserDto
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public bool? IsEmailVerified { get; set; }
}

public class LoginDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
