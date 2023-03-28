using Tutor.Shared.Enums;

namespace Tutor.Shared.Dtos;

public record CreateAdvertisementDto(string Title, string Description,
    EducationLevels Levels, Guid SubjectId, decimal PricePerHour)
{
    public static CreateAdvertisementDto WithDefaultValues()
        => new(default, default, default, default, default);
}
    