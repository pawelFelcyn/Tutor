namespace Tutor.Shared.Dtos;

public record LoginResponseDto(UserDetailsDto User, string Token);