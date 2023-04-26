namespace Tutor.Shared.Dtos;

public record ProfileImageDto
{
    public byte[] Bytes { get; set; }
    public Guid UserId { get; set; }
}

public record CreateProfileImageDto
{
    public CreateProfileImageDto()
    {
        
    }

    public CreateProfileImageDto(byte[] bytes)
    {
        Bytes = bytes;
    }

    public byte[] Bytes { get; set; }
}