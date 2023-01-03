using Microsoft.AspNetCore.Authorization;

namespace Tutor.Server.Application.Authentication;

public class RoleRequirement : Requirement<RoleRequirement>
{
	public RoleRequirement(string role)
	{
		Role = role;
	}

    public string Role { get; }
}
