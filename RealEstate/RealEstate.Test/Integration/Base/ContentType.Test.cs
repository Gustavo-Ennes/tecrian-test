namespace RealEstate.Test.Integration.Base;

public class ContentTypeTests(CustomWebApplicationFactory<Program> factory)
    : BaseIntegration(factory)
{
    [Theory]
    [InlineData("/api/tenant/legal")]
    [InlineData("/api/tenant/natural")]
    public async Task ShouldGetCorrectEndpointsContentType(string url)
    {
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        Assert.Equal(
            "application/json; charset=utf-8",
            response?.Content?.Headers?.ContentType?.ToString()
        );
    }
}
