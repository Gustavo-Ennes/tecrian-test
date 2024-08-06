namespace RealEstate.Test.Integration.Base;

[Collection("LegalTenant")]
public class ContentTypeTests(CustomWebApplicationFactory<Program> program): BaseIntegration(program)
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
