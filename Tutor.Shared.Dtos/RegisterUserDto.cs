namespace Tutor.Shared.Dtos;

public record RegisterUserDto(string FirstName, string LastName, string Role, string Email, string Password, string ConfirmPassword, string TutorDescription);
