namespace Tutor.Shared.Dtos;

public record ProfileImageDto
{
    public byte[] Bytes { get; set; }
    public Guid UserId { get; set; }
}

public record CreateProfileImageDto(byte[] Bytes);