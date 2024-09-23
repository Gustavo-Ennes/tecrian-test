namespace Tecrian.Shared.Utils.Hash;

public class HashUtils
{
  public static string HashPassword(string password)
  {
    return BCrypt.Net.BCrypt.HashPassword(password, 12);
  }

  public static bool VerifyPassword(string? password, string hashedPassword)
  {
    return BCrypt.Net.BCrypt.Verify(password ?? "", hashedPassword);
  }
}