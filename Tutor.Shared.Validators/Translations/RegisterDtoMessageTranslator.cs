using System.Diagnostics;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators.Translations;

internal class RegisterDtoMessageTranslator : AbstractTranslator<RegisterDtoValidationMessage>
{
    public RegisterDtoMessageTranslator(ILocalizationInfoProvider localizationInfoProvider) 
        : base(localizationInfoProvider)
    {
    }

    protected override string TranslateToEnglish(RegisterDtoValidationMessage message) => message switch
    {
        RegisterDtoValidationMessage.EmailNotEmpty => "Email must not be empty.",
        RegisterDtoValidationMessage.NotValidEmailAddress => "This is not a valid email address.",
        RegisterDtoValidationMessage.EmailTaken => "That email is taken.",
        RegisterDtoValidationMessage.PasswordNotEmpty => "Password must not be empty.",
        RegisterDtoValidationMessage.PasswordConstraints => "Password must contain at least 8 characters, one uppercase letter, one lowercase letter, one digit and one special character.",
        RegisterDtoValidationMessage.FirstNameNotEmpty => "First name must not be empty.",
        RegisterDtoValidationMessage.MaxFirstNameLength => "Maximum legth of first name is 50 characters.",
        RegisterDtoValidationMessage.LastNameNotEmpty => "Last name must not be empty.",
        RegisterDtoValidationMessage.MaxLastNameLength => "Maximum legth of last name is 50 characters.",
        RegisterDtoValidationMessage.RoleMustBeIn => "Role must be in [User, Tutor].",
        RegisterDtoValidationMessage.ConfirmPsswdEqualToPsswd => "Confirm password musy be equal to password.",
        RegisterDtoValidationMessage.TutorDescriptionNotEmpty => "Tutor description must not be empty.",
        RegisterDtoValidationMessage.MaxDescriptionLength => "Maximum length of tutor description is 500 characters.",
        RegisterDtoValidationMessage.UserCantAddDescription => "You have to be in role 'Tutor' to add tutor description.",
        _ => throw new UnreachableException()
    };
    

    protected override string TranslateToPolish(RegisterDtoValidationMessage message) => message switch
    {
        RegisterDtoValidationMessage.EmailNotEmpty => "Email nie może być pusty.",
        RegisterDtoValidationMessage.NotValidEmailAddress => "Niepoprawny email.",
        RegisterDtoValidationMessage.EmailTaken => "Ten adres email jest już zajęty.",
        RegisterDtoValidationMessage.PasswordNotEmpty => "Hasło nie może być puste.",
        RegisterDtoValidationMessage.PasswordConstraints => "Hasło musi zawierać minimum 8 znaków, jedną małą i jedną wielką literę, cyfrę oraz znak specjalny.",
        RegisterDtoValidationMessage.FirstNameNotEmpty => "Imię nie może być puste.",
        RegisterDtoValidationMessage.MaxFirstNameLength => "Maksymalna długość imienia to 80 znaków.",
        RegisterDtoValidationMessage.LastNameNotEmpty => "Nazwisko nie może być puste.",
        RegisterDtoValidationMessage.MaxLastNameLength => "Maksymalna długość nazwiska to 80 znaków.",
        RegisterDtoValidationMessage.RoleMustBeIn => "Rola musi być w [Użytkownik, Korepetytor].",
        RegisterDtoValidationMessage.ConfirmPsswdEqualToPsswd => "Wartość pola 'Potwierdź hasło' musi być równa wartości pola 'Hasło'.",
        RegisterDtoValidationMessage.TutorDescriptionNotEmpty => "Opis nie może być pusty.",
        RegisterDtoValidationMessage.MaxDescriptionLength => "Maksymalna długość opisu to 500 znaków.",
        RegisterDtoValidationMessage.UserCantAddDescription => "Musisz być w roli 'Korepetytor', aby dodać opis.",
        _ => throw new UnreachableException()
    };
}
