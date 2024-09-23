using RestSharp;

namespace Tecrian.Infra.Email;

public interface IEmailSender
{
  public RestResponse SendEmail(EmailArgs args);
}