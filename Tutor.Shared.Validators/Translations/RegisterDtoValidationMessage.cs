namespace Tutor.Shared.Validators.Translations;

public enum RegisterDtoValidationMessage
{
    EmailNotEmpty,
    NotValidEmailAddress,
    EmailTaken,
    PasswordNotEmpty,
    PasswordConstraints,
    FirstNameNotEmpty,
    MaxFirstNameLength,
    LastNameNotEmpty,
    MaxLastNameLength,
    RoleMustBeIn,
    ConfirmPsswdEqualToPsswd,
    TutorDescriptionNotEmpty,
    MaxDescriptionLength,
    UserCantAddDescription
}
