namespace Tutor.Server.Domain.Entities;

public class ProfileImage
{
    public Guid Id { get; set; }
    public byte[] Bytes { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
