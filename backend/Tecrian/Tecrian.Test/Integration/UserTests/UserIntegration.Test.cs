using System.Text;
using Newtonsoft.Json;
using Tecrian.Shared.Dtos;
using Tecrian.Test.Integration.Base;
using Tecrian.Test.Utils;
using Tecrian.Test.DataAttributes.UserDto;
using System.Net;
using Tecrian.Test.DataAttributes.LogInDto;

namespace Tecrian.Test.Integration.UserTests;

[Collection("User")]
public class UserTests(
    CustomWebApplicationFactory<Program> factory
) : BaseIntegration(factory)
{
    [Fact]
    public async Task ShouldSignUp()
    {
        var dto =
            CreateUserDtoDataAttribute_Valid.GetUser();
        var dtoJson = new StringContent(
            JsonConvert.SerializeObject(dto),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _client.PostAsync("/api/user/signup", dtoJson);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseString);
        var token = tokenResponse?.Token ?? "";

        Assert.True(IntegrationUtils.IsValidJwt(token), "O token JWT é inválido.");

        var tokenPayload = IntegrationUtils.DecodeJwtToken(token);
        Assert.NotNull(tokenPayload);
        Assert.NotNull(tokenPayload["sub"]);
    }

    [Theory]
    [CreateUserDtoDataAttribute_Invalid]
    public async Task ShouldNotSignUp(CreateUserDto dto)
    {
        var dtoJson = new StringContent(
            JsonConvert.SerializeObject(dto),
            Encoding.UTF8,
            "application/json"
        );
        var response = await _client.PostAsync("/api/user/signup", dtoJson);
        var responseString = await response.Content.ReadAsStringAsync();
        var validationErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(responseString);
        
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("Sign up validation error", validationErrorResponse?.Title);
        Assert.NotEmpty(validationErrorResponse?.Errors ?? []);
    }

    [Fact]
    public async Task LoginUser()
    {
        CreateUserDto userDto = CreateUserDtoDataAttribute_Valid.GetUser();
        LoginDto loginDto = new()
        {
            Email = userDto.Email,
            Password = userDto.Password
        };
        StringContent loginDtoJson = new(
            JsonConvert.SerializeObject(loginDto),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _client.PostAsync("/api/user/login", loginDtoJson);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseString);
        var token = tokenResponse?.Token ?? "";

        Assert.True(IntegrationUtils.IsValidJwt(token), "O token JWT é inválido.");

        var tokenPayload = IntegrationUtils.DecodeJwtToken(token);
        Assert.NotNull(tokenPayload);
        Assert.NotNull(tokenPayload["sub"]);
    }

    [Theory]
    [LoginDtoDataAttribute_Invalid]
    public async Task ShouldNotLogin(LoginDto dto)
    {
        var dtoJson = new StringContent(
            JsonConvert.SerializeObject(dto),
            Encoding.UTF8,
            "application/json"
        );
        var response = await _client.PostAsync("/api/user/login", dtoJson);
        var responseString = await response.Content.ReadAsStringAsync();
        var validationErrorResponse = JsonConvert.DeserializeObject<ValidationErrorResponse>(responseString);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Equal("Login validation error", validationErrorResponse?.Title);
        Assert.NotEmpty(validationErrorResponse?.Errors ?? []);
    }
}
