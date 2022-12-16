using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tutor.Server.Domain.Entities;
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

    [Fact]
    public async Task Login_ForGoodCredentials_ReturnsOkStatusCode()
    {
        var dto = new LoginDto("email", "password");
        SeedUser();
        var client = _factory.CreateClient();
        var resposne = await client.PostAsJsonAsync("api/authentication/login", dto);
        resposne.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    private void SeedUser()
    {
        var scope = _factory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<TutorDbContext>();
        var hasher = scope.ServiceProvider.GetService<IPasswordHasher<User>>();
        var user = new User
        {
            FirstName = "Test",
            LastName = "Test",
            Role = "Test",
            Email = "email",
        };
        user.PasswordHash = hasher!.HashPassword(user, "password");
        dbContext!.Users.Add(user);
        dbContext.SaveChanges();
    }

    [Fact]
    public async Task Login_ForInvalidPassword_ReturnsUnauthorizedStatusCode()
    {
        var dto = new LoginDto("email", "bad");
        SeedUser();
        var client = _factory.CreateClient();
        var resposne = await client.PostAsJsonAsync("api/authentication/login", dto);
        resposne.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Login_ForInvalidEmail_ReturnsUnauthorizedStatusCode()
    {
        var dto = new LoginDto("bad", "password");
        SeedUser();
        var client = _factory.CreateClient();
        var resposne = await client.PostAsJsonAsync("api/authentication/login", dto);
        resposne.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
