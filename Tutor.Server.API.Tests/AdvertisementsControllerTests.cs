using Tutor.Shared.Enums;

namespace Tutor.Server.API.Tests;

public class AdvertisementsControllerTests : ControllerTests
{
	public AdvertisementsControllerTests(WebApplicationFactory<Program> factory)
		: base(factory)
	{

	}

	[Fact]
	public async Task Create_ForValidModelAndClaimsPrincipal_ReturnsCreatedStatusCode()
	{
		var user = SeedUser("Tutor");
		var factory = _factory.WithClaimsPrincipal(user);
		var client = factory.CreateClient();
		var model = new CreateAdvertisementDto("title", "description", EducationLevels.High, Subject.English, 50);
		var response = await client.PostAsJsonAsync("api/advertisements", model);
		response.StatusCode.Should().Be(HttpStatusCode.Created);
	}

	[Fact]
	public async Task Create_ForNotAuthenticatedUser_ReturnsUnauthorizedStatusCode()
	{
		var client = _factory.CreateClient();
        var model = new CreateAdvertisementDto("title", "description", EducationLevels.High, Subject.English, 50);
        var response = await client.PostAsJsonAsync("api/advertisements", model);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

	[Fact]
	public async Task Create_ForUserWithBadRole_ReturnsForbiddenStatusCode()
	{
        var user = SeedUser("User");
        var factory = _factory.WithClaimsPrincipal(user);
        var client = factory.CreateClient();
        var model = new CreateAdvertisementDto("title", "description", EducationLevels.High, Subject.English, 50);
        var response = await client.PostAsJsonAsync("api/advertisements", model);
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }

	[Fact]
	public async Task Create_ForInvalidModel_ReturnsBadRequestStatusCode()
	{
        var client = _factory.CreateClient();
        var model = new CreateAdvertisementDto(null, null, EducationLevels.High, Subject.English, 50);
        var response = await client.PostAsJsonAsync("api/advertisements", model);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

	[Fact]
	public async Task Get_ForExistingAdvertisement_ReturnsOkStatusCode()
	{
		var ad = SeedAdvertisement();
		var client = _factory.CreateClient();
		var response = await client.GetAsync($"api/advertisements/{ad.Id}");
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}

	[Fact]
	public async Task Get_ForNotExistongAdvertisement_ReturnsNotFoundStatusCode()
	{
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"api/advertisements/{Guid.NewGuid()}");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

	[Fact]
	public async Task GetAll_WithoutQueryParameters_ReturnsOkStatusCode()
	{
        var client = _factory.CreateClient();
        var response = await client.GetAsync($"api/advertisements");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
