﻿using FluentValidation;
using Tutor.Shared.Dtos;

namespace Tutor.Shared.Validators;

internal class LoginDtoValidator : AbstractValidator<LoginDto>
{
	public LoginDtoValidator()
	{
		RuleFor(l => l.Password)
			.NotEmpty()
			.WithMessage("Password must not be empty.");

		RuleFor(l => l.Email)
			.NotEmpty()
			.WithMessage("Email must not be empty.");
    }
}