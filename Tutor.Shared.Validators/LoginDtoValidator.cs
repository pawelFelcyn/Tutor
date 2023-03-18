using FluentValidation;
using Tutor.Shared.Dtos;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators;

internal class LoginDtoValidator : AbstractValidator<LoginDto>
{
	public LoginDtoValidator(ITranslator<LoginDtoValidationMessage> translator)
	{
		RuleFor(l => l.Password)
			.NotEmpty()
			.WithMessage(translator.Translate(LoginDtoValidationMessage.PasswordMustNotBeEmpty));

		RuleFor(l => l.Email)
			.NotEmpty()
			.WithMessage(translator.Translate(LoginDtoValidationMessage.EmailMustNotBeEmpty));
    }
}
