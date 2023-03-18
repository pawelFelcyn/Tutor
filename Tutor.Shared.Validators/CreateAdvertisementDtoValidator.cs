using FluentValidation;
using Tutor.Shared.Dtos;
using Tutor.Shared.Helpers.Abstractions;
using Tutor.Shared.Validators.Translations;

namespace Tutor.Shared.Validators;

internal class CreateAdvertisementDtoValidator : AbstractValidator<CreateAdvertisementDto>
{
	public CreateAdvertisementDtoValidator(ISubjectValidationHelper subjectValidationHelper, 
		ITranslator<CreateAdvertisementDtoValidationMessage> translator)
	{
		RuleFor(m => m.Title)
			.MaximumLength(100)
			.WithMessage(translator.Translate(CreateAdvertisementDtoValidationMessage.MaxTitleLength))
			.NotEmpty()
			.WithMessage(translator.Translate(CreateAdvertisementDtoValidationMessage.TitleNotEmpty));

		RuleFor(m => m.Description)
			.MaximumLength(1000)
			.WithMessage(translator.Translate(CreateAdvertisementDtoValidationMessage.MaxDescriptionLength));

		RuleFor(m => m.PricePerHour)
			.GreaterThan(0)
			.WithMessage(translator.Translate(CreateAdvertisementDtoValidationMessage.PricePositive));

		RuleFor(m => m.SubjectId)
			.Must(subjectValidationHelper.Exists)
			.WithMessage(translator.Translate(CreateAdvertisementDtoValidationMessage.NonexistingSubject));
	}
}
