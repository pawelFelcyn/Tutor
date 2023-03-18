using Tutor.Shared.Validators.Translations;

namespace Tutor.Shared.Validators.Tests.Translations;

public class RegisterDtoMessageTranslatorTests : TranslatorTests
{
	private RegisterDtoMessageTranslator _englishTranslator;
	private RegisterDtoMessageTranslator _polishTranslator;

	public RegisterDtoMessageTranslatorTests()
	{
		_englishTranslator = new(GetEnLocalizationProvider());
		_polishTranslator = new(GetPlLocalizationProvider());
	}

	[Theory]
	[InlineData(RegisterDtoValidationMessage.EmailNotEmpty, "Email must not be empty.")]
	[InlineData(RegisterDtoValidationMessage.NotValidEmailAddress, "This is not a valid email address.")]
	[InlineData(RegisterDtoValidationMessage.EmailTaken, "That email is taken.")]
	[InlineData(RegisterDtoValidationMessage.PasswordNotEmpty, "Password must not be empty.")]
	[InlineData(RegisterDtoValidationMessage.PasswordConstraints, "Password must contain at least 8 characters, one uppercase letter, one lowercase letter, one digit and one special character.")]
	[InlineData(RegisterDtoValidationMessage.FirstNameNotEmpty, "First name must not be empty.")]
	[InlineData(RegisterDtoValidationMessage.MaxFirstNameLength, "Maximum legth of first name is 50 characters.")]
	[InlineData(RegisterDtoValidationMessage.LastNameNotEmpty, "Last name must not be empty.")]
	[InlineData(RegisterDtoValidationMessage.MaxLastNameLength, "Maximum legth of last name is 50 characters.")]
	[InlineData(RegisterDtoValidationMessage.RoleMustBeIn, "Role must be in [User, Tutor].")]
	[InlineData(RegisterDtoValidationMessage.ConfirmPsswdEqualToPsswd, "Confirm password musy be equal to password.")]
	[InlineData(RegisterDtoValidationMessage.TutorDescriptionNotEmpty, "Tutor description must not be empty.")]
	[InlineData(RegisterDtoValidationMessage.MaxDescriptionLength, "Maximum length of tutor description is 500 characters.")]
	[InlineData(RegisterDtoValidationMessage.UserCantAddDescription, "You have to be in role 'Tutor' to add tutor description.")]
	private void Translate_ShouldProperlyTranslateToEnglish(RegisterDtoValidationMessage msg, string expected)
	{
		_englishTranslator.Translate(msg).Should().Be(expected);
	}

    [Theory]
    [InlineData(RegisterDtoValidationMessage.EmailNotEmpty, "Email nie może być pusty.")]
    [InlineData(RegisterDtoValidationMessage.NotValidEmailAddress, "Niepoprawny email.")]
    [InlineData(RegisterDtoValidationMessage.EmailTaken, "Ten adres email jest już zajęty.")]
    [InlineData(RegisterDtoValidationMessage.PasswordNotEmpty, "Hasło nie może być puste.")]
    [InlineData(RegisterDtoValidationMessage.PasswordConstraints, "Hasło musi zawierać minimum 8 znaków, jedną małą i jedną wielką literę, cyfrę oraz znak specjalny.")]
    [InlineData(RegisterDtoValidationMessage.FirstNameNotEmpty, "Imię nie może być puste.")]
    [InlineData(RegisterDtoValidationMessage.MaxFirstNameLength, "Maksymalna długość imienia to 80 znaków.")]
    [InlineData(RegisterDtoValidationMessage.LastNameNotEmpty, "Nazwisko nie może być puste.")]
    [InlineData(RegisterDtoValidationMessage.MaxLastNameLength, "Maksymalna długość nazwiska to 80 znaków.")]
    [InlineData(RegisterDtoValidationMessage.RoleMustBeIn, "Rola musi być w [Użytkownik, Korepetytor].")]
    [InlineData(RegisterDtoValidationMessage.ConfirmPsswdEqualToPsswd, "Wartość pola 'Potwierdź hasło' musi być równa wartości pola 'Hasło'.")]
    [InlineData(RegisterDtoValidationMessage.TutorDescriptionNotEmpty, "Opis nie może być pusty.")]
    [InlineData(RegisterDtoValidationMessage.MaxDescriptionLength, "Maksymalna długość opisu to 500 znaków.")]
    [InlineData(RegisterDtoValidationMessage.UserCantAddDescription, "Musisz być w roli 'Korepetytor', aby dodać opis.")]
    private void Translate_ShouldProperlyTranslateToPolish(RegisterDtoValidationMessage msg, string expected)
    {
        _polishTranslator.Translate(msg).Should().Be(expected);
    }
}
