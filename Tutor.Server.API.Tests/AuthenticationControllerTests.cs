using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tutor.Server.Domain.Entities;
using Tutor.Server.Infrastructure.Database;

namespace Tutor.Server.API.Tests;

public class AuthenticationControllerTests : ControllerTests
{
    public AuthenticationControllerTests(WebApplicationFactory<Program> factory)
        :base(factory)
	{
	}

    [Fact]
    public async Task Register_ForValidModel_ReturnsOkStatusCode()
    {
        var dto = new RegisterUserDto("John", "Smith", "User", "email@email.com", "!Password123", "!Password123", null);
        var client = _factory.CreateClient();
        var result = await client.PostAsJsonAsync("api/authentication/register", dto);
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Register_ForInvalidModel_ReturnsBadRequestStatusCode()
    {
        var dto = new RegisterUserDto(null, null, null, null, null, null, null);
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

    [Fact]
    public async Task Login_ForBadModel_ReturnsBadRequestStatusCode()
    {
        var dto = new LoginDto(null, null);
        var client = _factory.CreateClient();
        var resposne = await client.PostAsJsonAsync("api/authentication/login", dto);
        resposne.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task RefreshToken_ForUnauthenticatedUser_ReturnsUnauthorizedStatusCode()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("api/authentication/refreshToken");
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task RefreshToken_ForAuthenticatedUser_ReturnsOkStatusCode()
    {
        var user = SeedUser();
        var client = _factory.WithClaimsPrincipal(user).CreateClient();
        var response = await client.GetAsync("api/authentication/refreshToken");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
