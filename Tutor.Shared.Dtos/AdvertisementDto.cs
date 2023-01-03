using Tutor.Shared.Enums;

namespace Tutor.Shared.Dtos;

public record AdvertisementDto
{
    public Guid Id { get; init; }
    public int Title { get; init; }
    public DateTime CreationDate { get; init; }
    public DateTime LastModificationDate { get; init;}
    public EducationLevels Levels { get; init; }
    public decimal PricePerHour { get; init; }
    public Currency Currency { get; init; }
    public LessonModes Modes { get; init; }

}
