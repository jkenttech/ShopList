namespace API.Tests;

public class RegisterControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public RegisterControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Theory]
    [InlineData("/register")]
    public async Task Post_RegisterLogin(string url)
    {
        HttpContent? content = null;
        var response = await _client.PostAsync(url, content);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
