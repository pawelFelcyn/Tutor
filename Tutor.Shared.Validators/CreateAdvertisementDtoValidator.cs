using FluentValidation;
using Tutor.Shared.Dtos;

namespace Tutor.Shared.Validators;

internal class CreateAdvertisementDtoValidator : AbstractValidator<CreateAdvertisementDto>
{
	public CreateAdvertisementDtoValidator()
	{
		RuleFor(m => m.Title)
			.MaximumLength(100)
			.WithMessage("Title must not have more than 100 characters.")
			.NotEmpty()
			.WithMessage("Title must not be empty.");

		RuleFor(m => m.Description)
			.MaximumLength(1000)
			.WithMessage("Description must not have more than 1000 characters.");
	}
}
