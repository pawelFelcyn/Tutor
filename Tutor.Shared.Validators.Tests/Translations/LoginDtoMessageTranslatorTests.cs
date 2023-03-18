using FluentAssertions;
using Tutor.Shared.Helpers.Abstractions;
using Tutor.Shared.Validators.Translations;

namespace Tutor.Shared.Validators.Tests.Translations;

public class LoginDtoMessageTranslatorTests
{
	private readonly LoginDtoMessageTranslator _polishTranslator;
	private readonly LoginDtoMessageTranslator _englishTranslator;

	public LoginDtoMessageTranslatorTests()
	{
		var polishLocalizationMock = new Mock<ILocalizationInfoProvider>();
		polishLocalizationMock.Setup(m => m.GetLocalizationInfo()).Returns("pl-PL");
		var englishLocalizationMock = new Mock<ILocalizationInfoProvider>();
        englishLocalizationMock.Setup(m => m.GetLocalizationInfo()).Returns("en-US");

		_polishTranslator = new(polishLocalizationMock.Object);
		_englishTranslator = new(englishLocalizationMock.Object);
	}

	[Theory]
	[InlineData(LoginDtoValidationMessage.PasswordMustNotBeEmpty, "Password must not be empty.")]
	[InlineData(LoginDtoValidationMessage.EmailMustNotBeEmpty, "Email must not be empty.")]
	private void Translate_ShouldProperlyTranslateToEnglish(LoginDtoValidationMessage msg, string expected)
	{
		_englishTranslator.Translate(msg).Should().Be(expected);
	}

    [Theory]
    [InlineData(LoginDtoValidationMessage.PasswordMustNotBeEmpty, "Hasło nie może być puste.")]
    [InlineData(LoginDtoValidationMessage.EmailMustNotBeEmpty, "Email nie może być pusty.")]
    private void Translate_ShouldProperlyTranslateToPolish(LoginDtoValidationMessage msg, string expected)
    {
        _polishTranslator.Translate(msg).Should().Be(expected);
    }
}
