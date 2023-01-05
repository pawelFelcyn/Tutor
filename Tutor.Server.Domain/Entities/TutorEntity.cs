namespace Tutor.Server.Domain.Entities;

public class TutorEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
