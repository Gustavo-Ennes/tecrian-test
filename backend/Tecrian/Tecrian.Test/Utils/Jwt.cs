using System.Text;
using Newtonsoft.Json;

namespace Tecrian.Test.Utils;

class IntegrationUtils
{
  public static bool IsValidJwt(string token)
  {
    var parts = token.Split('.');
    return parts.Length == 3;
  }
  public static IDictionary<string, object>? DecodeJwtToken(string token)
  {
    var parts = token.Split('.');
    if (parts.Length != 3)
      return null;

    var payload = parts[1];
    var base64 = ConvertBase64UrlToBase64(payload);

    try
    {
      var jsonBytes = Convert.FromBase64String(base64);
      var json = Encoding.UTF8.GetString(jsonBytes);
      return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Exception decoding JWT payload: {ex.Message}");
      return null;
    }
  }
  private static string ConvertBase64UrlToBase64(string base64Url)
  {
    var base64 = base64Url
        .Replace('-', '+') 
        .Replace('_', '/');

    switch (base64.Length % 4)
    {
      case 0:
        break;
      case 2:
        base64 += "==";
        break;
      case 3:
        base64 += "=";
        break;
      default:
        throw new InvalidOperationException("Invalid Base64Url string.");
    }

    return base64;
  }
}