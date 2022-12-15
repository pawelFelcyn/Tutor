using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Shared.Validators.Tests;

public class RegisterUserDtoValidatorTests
{
    private readonly RegisterUserDtoValidator _emailTakenValidator; 
    private readonly RegisterUserDtoValidator _emailNotTakenValidator; 

    public RegisterUserDtoValidatorTests()
    {
        var takenMock = new Mock<IEmailValidationHelper>();
        takenMock.Setup(m => m.IsEmailTaken(It.IsAny<string>())).Returns(true);
        _emailTakenValidator = new(takenMock.Object);
        var notTakenMock = new Mock<IEmailValidationHelper>();
        notTakenMock.Setup(m => m.IsEmailTaken(It.IsAny<string>())).Returns(false);
        _emailNotTakenValidator = new(takenMock.Object);
    }

    [Fact]
    public void Validate_ForValidModel_DoesNotReturnAnyErrors()
    {
        var model = new RegisterUserDto("John", "Smith", "User", "email@email.com", "!Password123", "!Password132");
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("sadffdsfsf")]
    public void Validate_ForInvalidEmail_ResultHasValidationError(string email)
    {
        var model = new RegisterUserDto(null, null, null, email, null, null);
        var result = _emailNotTakenValidator.TestValidate(model);
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
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(u => u.Password);
    }

    [Fact]
    public void Validate_ForTakenEmail_ResultHasValidationError()
    {
        var model = new RegisterUserDto(null, null, null, "email@email.com", null, null);
        var result = _emailTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("asdasdhaskljdlaskjdlaksdlkaskldjlaskdlasdjlaskjdlksajdlkasjdsadsakldjlksadlkasjskdlkasdjklasjdlkajdlksjdllajslkjlajdlksajdlsjdadkljjaslkd")]
    public void Validate_ForInvalidFirstName_ResultHasValidationError(string firstName)
    {
        var model = new RegisterUserDto(firstName, null, null, null, null, null);
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.FirstName);
    }
}
