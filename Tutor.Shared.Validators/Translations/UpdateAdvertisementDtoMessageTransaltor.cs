using System.Diagnostics;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators.Translations;

internal class UpdateAdvertisementDtoMessageTransaltor : AbstractTranslator<UpdateAdvertisementDtoValidationMessage>
{
    public UpdateAdvertisementDtoMessageTransaltor(ILocalizationInfoProvider localizationInfoProvider)
       : base(localizationInfoProvider)
    {
    }

    protected override string TranslateToEnglish(UpdateAdvertisementDtoValidationMessage message) => message switch
    {
        UpdateAdvertisementDtoValidationMessage.MaxTitleLength => "Title must not have more than 100 characters.",
        UpdateAdvertisementDtoValidationMessage.TitleNotEmpty => "Title must not be empty.",
        UpdateAdvertisementDtoValidationMessage.MaxDescriptionLength => "Description must not have more than 1000 characters.",
        UpdateAdvertisementDtoValidationMessage.PricePositive => "Price must be greather than 0.",
        _ => throw new UnreachableException()
    };

    protected override string TranslateToPolish(UpdateAdvertisementDtoValidationMessage message) => message switch
    {
        UpdateAdvertisementDtoValidationMessage.MaxTitleLength => "Maksymalna długość tytułu to 100 znaków.",
        UpdateAdvertisementDtoValidationMessage.TitleNotEmpty => "Tytuł nie może być pusty",
        UpdateAdvertisementDtoValidationMessage.MaxDescriptionLength => "Maksymalna długość opisu to 1000 znaków",
        UpdateAdvertisementDtoValidationMessage.PricePositive => "Cena musi być większa od 0.",
        _ => throw new UnreachableException()
    };
}
