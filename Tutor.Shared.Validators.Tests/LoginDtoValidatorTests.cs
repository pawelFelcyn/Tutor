namespace Tutor.Shared.Validators.Tests;

public class LoginDtoValidatorTests 
{
	private readonly LoginDtoValidator _validator;

	public LoginDtoValidatorTests()
	{
		_validator = new();
	}

	[Fact]
	public void Validate_ForValidModel_DOntHaveAnyErrors()
	{
		var model = new LoginDto("email", "password");
		var result = _validator.TestValidate(model);
		result.ShouldNotHaveAnyValidationErrors();
	}
}
