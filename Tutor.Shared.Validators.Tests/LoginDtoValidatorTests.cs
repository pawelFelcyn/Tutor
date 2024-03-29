﻿using System.Net.WebSockets;

namespace Tutor.Shared.Validators.Tests;

public class LoginDtoValidatorTests : ValidatorTests
{
	private readonly LoginDtoValidator _validator;

	public LoginDtoValidatorTests()
	{
		_validator = new(GetTranslator<LoginDtoValidationMessage>());
	}

	[Fact]
	public void Validate_ForValidModel_DOntHaveAnyErrors()
	{
		var model = new LoginDto("email", "password");
		var result = _validator.TestValidate(model);
		result.ShouldNotHaveAnyValidationErrors();
	}

	[Fact]
	public void Validate_ForInvalidPassword_ReturnsValidationError()
	{
        var model = new LoginDto("email", null);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.Password);
    }

    [Fact]
    public void Validate_ForInvalidEmail_ReturnsValidationError()
    {
        var model = new LoginDto(null, "password");
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }
}
