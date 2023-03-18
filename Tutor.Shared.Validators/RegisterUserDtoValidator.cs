using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tutor.Shared.Dtos;
using Tutor.Shared.Helpers.Abstractions;
using Tutor.Shared.Validators.Translations;

namespace Tutor.Shared.Validators;

internal class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
	private string[] _allowedRoles = new string[] { "User", "Tutor" };

	public RegisterUserDtoValidator(IEmailValidationHelper emailValidationHelper, ITranslator<RegisterDtoValidationMessage> translator)
	{
		RuleFor(u => u.Email)
			.NotEmpty()
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.EmailNotEmpty))
			.EmailAddress()
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.NotValidEmailAddress))
			.Must(e => !emailValidationHelper.IsEmailTaken(e))
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.EmailTaken));

		RuleFor(u => u.Password)
			.NotEmpty()
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.PasswordNotEmpty))
			.Must(p =>
			{
				if (p is null)
				{
					return true;
				}
				var pswdRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
				return pswdRegex.Match(p).Success;
			})
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.PasswordConstraints));

		RuleFor(u => u.FirstName)
			.NotEmpty()
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.FirstNameNotEmpty))
			.MaximumLength(50)
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.MaxFirstNameLength));

        RuleFor(u => u.LastName)
            .NotEmpty()
            .WithMessage(translator.Translate(RegisterDtoValidationMessage.LastNameNotEmpty))
            .MaximumLength(50)
            .WithMessage(translator.Translate(RegisterDtoValidationMessage.MaxLastNameLength));

		RuleFor(u => u.Role)
			.Must(r => _allowedRoles.Contains(r))
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.RoleMustBeIn));

		RuleFor(u => u.ConfirmPassword)
			.Equal(u => u.Password)
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.ConfirmPsswdEqualToPsswd));

		When(r => r.Role == "Tutor", () =>
		{
			RuleFor(r => r.TutorDescription)
			.NotEmpty()
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.TutorDescriptionNotEmpty))
			.MaximumLength(500)
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.MaxDescriptionLength));
		});

		When(r => r.Role == "User", () =>
		{
			RuleFor(r => r.TutorDescription)
			.Null()
			.WithMessage(translator.Translate(RegisterDtoValidationMessage.UserCantAddDescription));
		});
    }
}
