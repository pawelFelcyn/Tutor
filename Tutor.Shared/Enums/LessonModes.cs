namespace Tutor.Shared.Enums;

[Flags]
public enum LessonModes : short
{
    InPerson = 1 << 0,
    Remote = 1 << 1,
    Any = InPerson | Remote
}
