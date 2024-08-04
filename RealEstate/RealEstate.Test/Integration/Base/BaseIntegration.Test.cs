namespace RealEstate.Test.Integration.Base;

[Collection("Sequential")]
public class UserEndPointTest(CustomWebApplicationFactory<Program> factory)
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Theory]
    [InlineData("/api/tenant/legal")]
    [InlineData("/api/tenant/natural")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        Assert.Equal(
            "application/json; charset=utf-8",
            response?.Content?.Headers?.ContentType?.ToString()
        );
    }
}
