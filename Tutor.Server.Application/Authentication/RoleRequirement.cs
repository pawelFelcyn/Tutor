using Microsoft.AspNetCore.Authorization;

namespace Tutor.Server.Application.Authentication;

public class RoleRequirement : IAuthorizationRequirement
{
	public RoleRequirement(string role)
	{
		Role = role;
	}

    public string Role { get; }
}
