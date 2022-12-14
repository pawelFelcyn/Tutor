namespace Tutor.Shared.Validators.Tests;

public class RegisterUserDtoValidatorTests
{
    [Fact]
    public void Validate_ForValidModel_DoesNotReturnAnyErrors()
    {
        var model = new RegisterUserDto("John", "Smith", "User", "email@email.com", "!Password123", "!Password132");
        var validator = new RegisterUserDtoValidator();
        var result = validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
