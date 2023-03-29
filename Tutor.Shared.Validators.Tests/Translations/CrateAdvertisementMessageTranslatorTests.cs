using Tutor.Shared.Validators.Translations;

namespace Tutor.Shared.Validators.Tests.Translations;

public class CrateAdvertisementMessageTranslatorTests : TranslatorTests
{
	private readonly CreateAdvertisementDtoMessageTranslator _englishTranslator;
	private readonly CreateAdvertisementDtoMessageTranslator _polishTranslator;

	public CrateAdvertisementMessageTranslatorTests()
	{
		_englishTranslator = new(GetEnLocalizationProvider());
		_polishTranslator = new(GetPlLocalizationProvider());
	}

	[Theory]
	[InlineData(CreateAdvertisementDtoValidationMessage.MaxTitleLength, "Title must not have more than 100 characters.")]
	[InlineData(CreateAdvertisementDtoValidationMessage.TitleNotEmpty, "Title must not be empty.")]
	[InlineData(CreateAdvertisementDtoValidationMessage.MaxDescriptionLength, "Description must not have more than 1000 characters.")]
	[InlineData(CreateAdvertisementDtoValidationMessage.PricePositive, "Price must be greather than 0.")]
	[InlineData(CreateAdvertisementDtoValidationMessage.NonexistingSubject, "This subject does not exist.")]
	[InlineData(CreateAdvertisementDtoValidationMessage.NotSelectedLevels, "You must specify educationlevels.")]
	private void Translate_ShouldProperlyTranslateToEnglish(CreateAdvertisementDtoValidationMessage msg, string expected)
	{
		_englishTranslator.Translate(msg).Should().Be(expected);
	}

    [Theory]
    [InlineData(CreateAdvertisementDtoValidationMessage.MaxTitleLength, "Maksymalna długość tytułu to 100 znaków.")]
    [InlineData(CreateAdvertisementDtoValidationMessage.TitleNotEmpty, "Tytuł nie może być pusty")]
    [InlineData(CreateAdvertisementDtoValidationMessage.MaxDescriptionLength, "Maksymalna długość opisu to 1000 znaków")]
    [InlineData(CreateAdvertisementDtoValidationMessage.PricePositive, "Cena musi być większa od 0.")]
    [InlineData(CreateAdvertisementDtoValidationMessage.NonexistingSubject, "Ten przdmiot nie istnieje.")]
    [InlineData(CreateAdvertisementDtoValidationMessage.NotSelectedLevels, "Wybierz poziom (poziomy).")]
    private void Translate_ShouldProperlyTranslateToPolish(CreateAdvertisementDtoValidationMessage msg, string expected)
    {
        _polishTranslator.Translate(msg).Should().Be(expected);
    }
}
