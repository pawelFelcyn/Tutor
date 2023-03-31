namespace Tutor.Shared.Dtos;

public record UserDetailsDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Role { get; init; }
    public string Email { get; init; }
    public string Description { get; set; }
}
