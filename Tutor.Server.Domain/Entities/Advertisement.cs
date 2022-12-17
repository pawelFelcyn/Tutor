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
    public Subject Subject { get; set; }
    public decimal PricePerHour { get; set; }
    public Guid CreatedById { get; set; }
    public User CreatedBy { get; set; }
}
