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

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("sadffdsfsf")]
    public void Validate_ForInvalidEmail_ResultHasValidationError(string email)
    {
        var model = new RegisterUserDto(null, null, null, email, null, null);
        var validator = new RegisterUserDtoValidator();
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("adsasdadsadasdasdasdasd")]
    [InlineData("Pasdana")]
    [InlineData("!wF")]
    public void Validate_ForInvalidPassword_ResultHasValidationError(string password)
    {
        var model = new RegisterUserDto(null, null, null, null, password, null);
        var validator = new RegisterUserDtoValidator();
        var result = validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(u => u.Password);
    }
}
