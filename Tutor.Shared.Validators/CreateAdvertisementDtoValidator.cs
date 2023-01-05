using FluentValidation;
using Tutor.Shared.Dtos;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators;

internal class CreateAdvertisementDtoValidator : AbstractValidator<CreateAdvertisementDto>
{
	public CreateAdvertisementDtoValidator(ISubjectValidationHelper subjectValidationHelper)
	{
		RuleFor(m => m.Title)
			.MaximumLength(100)
			.WithMessage("Title must not have more than 100 characters.")
			.NotEmpty()
			.WithMessage("Title must not be empty.");

		RuleFor(m => m.Description)
			.MaximumLength(1000)
			.WithMessage("Description must not have more than 1000 characters.");

		RuleFor(m => m.PricePerHour)
			.GreaterThan(0)
			.WithMessage("Price must be greather than 0.");

		RuleFor(m => m.SubjectId)
			.Must(subjectValidationHelper.Exists)
			.WithMessage("This subject does not exist.");
	}
}
