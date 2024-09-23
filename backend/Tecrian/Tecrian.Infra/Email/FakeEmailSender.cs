namespace Tecrian.Infra.Email;
using RestSharp;

public class FakeEmailSender : IEmailSender
{  public RestResponse SendEmail(
    EmailArgs args
  )
  {
    Console.WriteLine( "Fake email sent." );

    return new RestResponse();
  }

}
