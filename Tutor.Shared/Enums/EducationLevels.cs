using NetEscapades.EnumGenerators;
using System.ComponentModel.DataAnnotations;

namespace Tutor.Shared.Enums;

[Flags]
public enum EducationLevels
{
    Preschool = 1 << 0,
    Primary = 1 << 1,
    Secondary = 1 << 2,
    High = 1 << 3,
    Studies = 1 << 4
}

