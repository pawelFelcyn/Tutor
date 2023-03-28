using Tutor.Shared.Enums;

namespace Tutor.Shared.Dtos;

public record CreateAdvertisementDto
{
    public CreateAdvertisementDto(string title, string description,
    EducationLevels levels, Guid subjectId, decimal pricePerHour)
    {
        Title = title;
        Description = description;
        Levels = levels;
        SubjectId = subjectId;
        PricePerHour = pricePerHour;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public EducationLevels Levels { get; set; }
    public Guid SubjectId { get; set; }
    public decimal PricePerHour { get; set; }

    public static CreateAdvertisementDto WithDefaultValues()
        => new(default, default, default, default, default);
}
    