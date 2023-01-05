namespace Tutor.Server.API.Tests;

public class SubjectsControllerTests : ControllerTests
{
    public SubjectsControllerTests(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAll_ReturnsOkStatusCode()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/subjects");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
