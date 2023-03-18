using Tutor.Shared.Validators.Translations;

namespace Tutor.Shared.Validators.Tests.Translations;

public class UpdateAdvertisementDtoMessageTranslatorTests : TranslatorTests
{
    private readonly UpdateAdvertisementDtoMessageTransaltor _englishTranslator;
    private readonly UpdateAdvertisementDtoMessageTransaltor _polishTranslator;

    public UpdateAdvertisementDtoMessageTranslatorTests()
    {
        _englishTranslator = new(GetEnLocalizationProvider());
        _polishTranslator = new(GetPlLocalizationProvider());
    }

    [Theory]
    [InlineData(UpdateAdvertisementDtoValidationMessage.MaxTitleLength, "Title must not have more than 100 characters.")]
    [InlineData(UpdateAdvertisementDtoValidationMessage.TitleNotEmpty, "Title must not be empty.")]
    [InlineData(UpdateAdvertisementDtoValidationMessage.MaxDescriptionLength, "Description must not have more than 1000 characters.")]
    [InlineData(UpdateAdvertisementDtoValidationMessage.PricePositive, "Price must be greather than 0.")]
    private void Translate_ShouldProperlyTranslateToEnglish(UpdateAdvertisementDtoValidationMessage msg, string expected)
    {
        _englishTranslator.Translate(msg).Should().Be(expected);
    }

    [Theory]
    [InlineData(UpdateAdvertisementDtoValidationMessage.MaxTitleLength, "Maksymalna długość tytułu to 100 znaków.")]
    [InlineData(UpdateAdvertisementDtoValidationMessage.TitleNotEmpty, "Tytuł nie może być pusty")]
    [InlineData(UpdateAdvertisementDtoValidationMessage.MaxDescriptionLength, "Maksymalna długość opisu to 1000 znaków")]
    [InlineData(UpdateAdvertisementDtoValidationMessage.PricePositive, "Cena musi być większa od 0.")]
    private void Translate_ShouldProperlyTranslateToPolish(UpdateAdvertisementDtoValidationMessage msg, string expected)
    {
        _polishTranslator.Translate(msg).Should().Be(expected);
    }
}
