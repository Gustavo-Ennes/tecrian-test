#pragma warning disable CS8604 // Possible null reference argument.
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Tecrian.Shared.Utils;

public class JwtUtils
{
  public static int? GetUserIdFromToken(string token, ILogger logger, IConfiguration configuration)
  {
    var jwtSettings = configuration.GetSection("JwtSettings");
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? ""));

    try
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = key
      }, out SecurityToken validatedToken);

      JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
      // Extract the user ID from the claims
      var userIdClaim = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
      if (string.IsNullOrEmpty(userIdClaim))
      {
        logger.LogWarning("User ID not found in token claims.");
        return null;
      }

      return int.Parse(userIdClaim);
    }
    catch (Exception err)
    {
      logger.LogError("Token authentication failed: {Message}", err.Message);
      throw;
    }
  }



  public static string GenerateJwtToken(int? id, string email, bool isVerified, ILogger logger, IConfiguration configuration)
  {
    var jwtSettings = configuration.GetSection("JwtSettings");
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? ""));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    if (id == null)
    {
      logger.LogError("Id is null: {id}", id);
      throw new ArgumentNullException(nameof(id));
    }

    var token = new JwtSecurityToken(
    issuer: jwtSettings["Issuer"],
    audience: jwtSettings["Audience"],
    claims:
    [
        new Claim(JwtRegisteredClaimNames.Sub, id.ToString()), 
        new Claim(JwtRegisteredClaimNames.Email, email),       
        new Claim("IsEmailVerified", isVerified.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    ],
    expires: DateTime.Now.AddMinutes(30),
    signingCredentials: creds);

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}