using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tutor.Shared.Dtos;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators;

internal class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
	private string[] _allowedRoles = new string[] { "User", "Tutor" };

	public RegisterUserDtoValidator(IEmailValidationHelper emailValidationHelper)
	{
		RuleFor(u => u.Email)
			.NotEmpty()
			.WithMessage("Email must not be empty.")
			.EmailAddress()
			.WithMessage("This is not a valid email address.")
			.Must(e => !emailValidationHelper.IsEmailTaken(e))
			.WithMessage("That email is taken.");

		RuleFor(u => u.Password)
			.NotEmpty()
			.WithMessage("Password must not be empty.")
			.Must(p =>
			{
				if (p is null)
				{
					return true;
				}
				var pswdRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
				return pswdRegex.Match(p).Success;
			})
			.WithMessage("Password must contain at lest 8 characters, one uppercase letter, one lowercase letter, one digit and one special character.");

		RuleFor(u => u.FirstName)
			.NotEmpty()
			.WithMessage("First name must not be empty.")
			.MaximumLength(50)
			.WithMessage("Maximum legth of first name is 50 characters.");

        RuleFor(u => u.LastName)
            .NotEmpty()
            .WithMessage("Last name must not be empty.")
            .MaximumLength(50)
            .WithMessage("Maximum legth of last name is 50 characters.");

		RuleFor(u => u.Role)
			.Must(r => _allowedRoles.Contains(r))
			.WithMessage($"Role must be in [{string.Join(",", _allowedRoles)}].");

		RuleFor(u => u.ConfirmPassword)
			.Equal(u => u.Password)
			.WithMessage("Confirm password musy be equal to password.");

		When(r => r.Role == "Tutor", () =>
		{
			RuleFor(r => r.TutorDescription)
			.NotEmpty()
			.WithMessage("Tutor description must not me empty.")
			.MaximumLength(500)
			.WithMessage("Maximum length of tutor description is 500 characters.");
		});

		When(r => r.Role == "User", () =>
		{
			RuleFor(r => r.TutorDescription)
			.Null()
			.WithMessage("You have to be in role 'Tutor' to add tutor description.");
		});
    }
}
