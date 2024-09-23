namespace Tecrian.Test.Integration.Base;

public class ContentTypeTests(CustomWebApplicationFactory<Program> program): BaseIntegration(program)
{
    [Theory]
    [InlineData("/api/user")]
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
