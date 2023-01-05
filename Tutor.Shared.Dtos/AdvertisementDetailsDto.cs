using Tutor.Shared.Enums;

namespace Tutor.Shared.Dtos;

public record AdvertisementDetailsDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public DateTime CreationDate { get; init; }
    public DateTime LastModificationDate { get; init; }
    public EducationLevels Levels { get; init; }
    public string Subject { get; init; }
    public decimal PricePerHour { get; init; }
    public Guid CreatedById { get; init; }
}
