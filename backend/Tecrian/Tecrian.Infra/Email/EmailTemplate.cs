namespace Tecrian.Infra.Email;

public class EmailTemplate
{
  public static string Get(int? userId, string token)
  {
    return $@"<!DOCTYPE html>
        <html lang = 'en'>
        <head>
            <meta charset = 'UTF-8'>
            <meta name = 'viewport' content = 'width=device-width, initial-scale=1.0'>
            <title> Confirm Your Email</title>
            <style>
                /* In-line Tailwind CSS styles for email */
                .bg - gray - 100 {{
        background - color: #f7fafc; }}
                .bg - white {{
            background - color: #ffffff; }}
                .text - gray - 900 {{
              color: #1a202c; }}
                .text - blue - 500 {{
                  color: #3182ce; }}
                .border {{border: 1px solid #e2e8f0; }}
                .rounded - lg {{ border - radius: 0.5rem; }}
                .shadow {{ box - shadow: 0 1px 3px rgba(0, 0, 0, 0.1); }}
                .p - 6 {{ padding: 1.5rem; }}
                .text - center {{ text - align: center; }}
                .font - bold {{ font - weight: 700; }}
                .text - lg {{ font - size: 1.125rem; }}
                .hover: bg - blue - 600 {{
                            background - color: #2b6cb0; }}
                .hover: text - white {{
                              color: #ffffff; }}
                .w - full {{ width: 100 %; }}
                .text - white {{
                                  color: #ffffff; }}
            </style>
        </head>
        <body class='bg-gray-100'>
            <div class='max-w-md mx-auto bg-white border rounded-lg shadow'>
                <div class='p-6 text-center'>
                    <h1 class='text-lg font-bold text-gray-900'>Welcome to Our Service!</h1>
                    <p class='mt-4 text-gray-600'>
                        Thank you for registering with us.To complete your registration, please confirm your email address by clicking the button below.
                    </p>
                    <a href = 'http://localhost:5000/api/user/confirmEmail/{userId}/{token}'
                       class='inline-block mt-6 px-6 py-3 bg-blue-500 text-white rounded-lg shadow hover:bg-blue-600'
                       target='_blank'>
                       Confirm Your Email
                    </a>
                    <p class='mt-4 text-gray-600 text-sm'>
                        If you did not register for this account, please ignore this email.
                    </p>
                </div>
            </div>
        </body>
    </html>";
  }
}