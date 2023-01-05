using Tutor.Shared.Enums;

namespace Tutor.Server.Domain.Entities;

public class Advertisement
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastModificationDate { get; set; }
    public EducationLevels Levels { get; set; }
    public decimal PricePerHour { get; set; }
    public Currency Currency { get; set; }
    public LessonModes Modes { get; set; }

    public Guid CreatedById { get; set; }
    public virtual User CreatedBy { get; set; }

    public Guid SubjectId { get; set; }
    public virtual SchoolSubject Subject { get; set; }
}
