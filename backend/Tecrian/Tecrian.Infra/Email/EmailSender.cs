namespace Tecrian.Infra.Email;

using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

public class EmailSender(IConfiguration config) : IEmailSender
{
  private readonly string _mailtrapApi = "https://send.api.mailtrap.io/api";
  private readonly string _contentType = "application/json";
  private readonly IConfiguration _config = config;

  public RestResponse SendEmail(
    EmailArgs args
  )
  {
    RestClient? client = new(_mailtrapApi);
    RestRequest? request = new("/send", Method.Post);
    string? token = _config["mailtrap_api"];
    
    request.AddHeader("Authorization", $"Bearer {token}");
    request.AddHeader("Content-Type", _contentType);
    request.AddParameter(
      _contentType,
      JsonSerializer.Serialize(args), ParameterType.RequestBody
    );

    RestResponse response = client.Execute(request);

    return response;
  }

}

public class EmailArgs
{
  public List<EmailSenderActor> To { get; set; } = [];
  public EmailSenderActor From { get; set; } = null!;
  public string Subject { get; set; } = null!;
  public string Html { get; set; } = null!;
  public string Text { get; set; } = null!;
  public string Category { get; set; } = null!;
}

public class EmailSenderActor
{
  public string Email { get; set; } = null!;
  public string? Name { get; set; }
}