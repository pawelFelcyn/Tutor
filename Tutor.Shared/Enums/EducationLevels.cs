namespace Tutor.Shared.Enums;

[Flags]
public enum EducationLevels
{
    Preschool = 2 >> 1,
    Primary = 2 >> 2,
    Secondary = 2 >> 3,
    High = 2 >> 4,
    Studies = 2 >> 5
}

