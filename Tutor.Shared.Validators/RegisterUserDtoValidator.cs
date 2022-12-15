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
			.WithMessage("Password must contain at lest 8 characters, one uppercase letter, one loercase letter, one digit and one special character.");
	}
}
