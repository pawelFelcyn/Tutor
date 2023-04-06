using AutoMapper.Configuration.Annotations;
using Tutor.Server.API.Tests.Helpers;
using Tutor.Shared.Dtos;

namespace Tutor.Server.API.Tests;

public class ImagesControllerTests : ControllerTests
{
    public ImagesControllerTests(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    private async Task Create_ForUnauthenticatedUser_ReturnsUnauthorizedStatusCode()
    {
        var client = _factory.CreateClient();
        var model = new CreateProfileImageDto(new byte[0]);
        var response = await client.PostAsJsonAsync("api/images", model);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    private async Task Create_ForAuthenticatedUser_ReturnsCreatedStatusCode()
    {
        var user = SeedUser();
        var client = _factory.WithClaimsPrincipal(user).CreateClient();
        var model = new CreateProfileImageDto(new byte[0]);
        var response = await client.PostAsJsonAsync("api/images", model);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    private async Task Create_ForAuthenticatedUserWithProfileImage_ReturnsCreatedStatusCode()
    {
        var user = SeedUser();
        SeedProfileImage(user.Id);
        var client = _factory.WithClaimsPrincipal(user).CreateClient();
        var model = new CreateProfileImageDto(new byte[0]);
        var response = await client.PostAsJsonAsync("api/images", model);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    private async Task Create_ForInvalidModel_ReturnsBadRequestStatusCode()
    {
        var user = SeedUser();
        var client = _factory.WithClaimsPrincipal(user).CreateClient();
        var model = new CreateProfileImageDto(null);
        var response = await client.PostAsJsonAsync("api/images", model);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
