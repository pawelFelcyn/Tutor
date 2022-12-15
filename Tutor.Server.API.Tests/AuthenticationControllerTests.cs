using Microsoft.EntityFrameworkCore;
using Tutor.Server.Infrastructure.Database;

namespace Tutor.Server.API.Tests;

public class AuthenticationControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AuthenticationControllerTests(WebApplicationFactory<Program> factory)
	{
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var dbContextService = services.FirstOrDefault(s => s.ServiceType == typeof(TutorDbContext));
                services.Remove(dbContextService!);
                var optionsBuilder = new DbContextOptionsBuilder();
                optionsBuilder.UseInMemoryDatabase("TutorDb");
                var context = new TutorDbContext(optionsBuilder.Options);
                services.AddSingleton(context);
            });
        });
	}

    [Fact]
    public async Task Register_ForValidModel_ReturnsOkStatusCode()
    {
        var dto = new RegisterUserDto("John", "Smith", "User", "email@email.com", "!Password123", "!Password132");
        var client = _factory.CreateClient();
        var result = await client.PostAsJsonAsync("api/authentication/register", dto);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Register_ForInvalidModel_ReturnsBadRequestStatusCode()
    {
        var dto = new RegisterUserDto(null, null, null, null, null, null);
        var client = _factory.CreateClient();
        var result = await client.PostAsJsonAsync("api/authentication/register", dto);
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
