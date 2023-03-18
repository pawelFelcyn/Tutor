using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators.Translations;

internal class CreateAdvertisementDtoMessageTranslator : AbstractTranslator<CreateAdvertisementDtoValidationMessage>
{
    public CreateAdvertisementDtoMessageTranslator(ILocalizationInfoProvider localizationInfoProvider) 
        : base(localizationInfoProvider)
    {
    }

    protected override string TranslateToEnglish(CreateAdvertisementDtoValidationMessage message) => message switch
    {
        CreateAdvertisementDtoValidationMessage.MaxTitleLength => "Title must not have more than 100 characters.",
        CreateAdvertisementDtoValidationMessage.TitleNotEmpty => "Title must not be empty.",
        CreateAdvertisementDtoValidationMessage.MaxDescriptionLength => "Description must not have more than 1000 characters.",
        CreateAdvertisementDtoValidationMessage.PricePositive => "Price must be greather than 0.",
        CreateAdvertisementDtoValidationMessage.NonexistingSubject => "This subject does not exist.",
        _ => throw new UnreachableException()
    };

    protected override string TranslateToPolish(CreateAdvertisementDtoValidationMessage message) => message switch
    {
        CreateAdvertisementDtoValidationMessage.MaxTitleLength => "Maksymalna długość tytułu to 100 znaków.",
        CreateAdvertisementDtoValidationMessage.TitleNotEmpty => "Tytuł nie może być pusty",
        CreateAdvertisementDtoValidationMessage.MaxDescriptionLength => "Maksymalna długość opisu to 1000 znaków",
        CreateAdvertisementDtoValidationMessage.PricePositive => "Cena musi być większa od 0.",
        CreateAdvertisementDtoValidationMessage.NonexistingSubject => "Ten przdmiot nie istnieje.",
        _ => throw new UnreachableException()
    };
}
