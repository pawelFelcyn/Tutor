using FluentValidation;
using Tutor.Shared.Dtos;
using Tutor.Shared.Validators.Translations;

namespace Tutor.Shared.Validators;

internal class UpdateAdvertisementDtoValidator : AbstractValidator<UpdateAdvertisementDto>
{
	public UpdateAdvertisementDtoValidator(ITranslator<UpdateAdvertisementDtoValidationMessage> translator)
	{
        RuleFor(m => m.Title)
            .MaximumLength(100)
            .WithMessage(translator.Translate(UpdateAdvertisementDtoValidationMessage.MaxTitleLength))
            .NotEmpty()
            .WithMessage(translator.Translate(UpdateAdvertisementDtoValidationMessage.TitleNotEmpty));

        RuleFor(m => m.Description)
            .MaximumLength(1000)
            .WithMessage(translator.Translate(UpdateAdvertisementDtoValidationMessage.MaxDescriptionLength));

        RuleFor(m => m.PricePerHour)
            .GreaterThan(0)
            .WithMessage(translator.Translate(UpdateAdvertisementDtoValidationMessage.PricePositive));
    }
}
