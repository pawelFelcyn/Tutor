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
        _emailNotTakenValidator = new(notTakenMock.Object);
    }

    [Fact]
    public void Validate_ForValidModel_DoesNotReturnAnyErrors()
    {
        var model = new RegisterUserDto("John", "Smith", "User", "email@email.com", "!Password123", "!Password123", null);
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("sadffdsfsf")]
    public void Validate_ForInvalidEmail_ResultHasValidationError(string email)
    {
        var model = new RegisterUserDto(null, null, null, email, null, null, null);
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
        var model = new RegisterUserDto(null, null, null, null, password, null, null);
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(u => u.Password);
    }

    [Fact]
    public void Validate_ForTakenEmail_ResultHasValidationError()
    {
        var model = new RegisterUserDto(null, null, null, "email@email.com", null, null, null);
        var result = _emailTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.Email);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("asdasdhaskljdlaskjdlaksdlkaskldjlaskdlasdjlaskjdlksajdlkasjdsadsakldjlksadlkasjskdlkasdjklasjdlkajdlksjdllajslkjlajdlksajdlsjdadkljjaslkd")]
    public void Validate_ForInvalidFirstName_ResultHasValidationError(string firstName)
    {
        var model = new RegisterUserDto(firstName, null, null, null, null, null, null);
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.FirstName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("asdasdhaskljdlaskjdlaksdlkaskldjlaskdlasdjlaskjdlksajdlkasjdsadsakldjlksadlkasjskdlkasdjklasjdlkajdlksjdllajslkjlajdlksajdlsjdadkljjaslkd")]
    public void Validate_ForInvalidLastName_ResultHasValidationError(string lastName)
    {
        var model = new RegisterUserDto(null, lastName, null, null, null, null, null);
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.LastName);
    }

    [Fact]
    public void Validate_ForInvalidRole_ResultHasValidationError()
    {
        var model = new RegisterUserDto(null, null, null, null, null, null, null);
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.Role);
    }

    [Fact]
    public void Validate_ForInvalidConfirmPassword_ResultHasValidationError()
    {
        var model = new RegisterUserDto(null, null, null, null, "!Password123", "!78d7asahjkdhsa7", null);
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.ConfirmPassword);
    }

    [Fact]
    public void Validate_ForUserRole_RequiresTutorDescriptionToBeEmpty()
    {
        var model = new RegisterUserDto(null, null, "User", null, null, null, "Description");
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(r => r.TutorDescription);
    }

    [Fact]
    public void Validate_ForTutorRole_RequiresTutorDescriptionNotToBeEmpty()
    {
        var model = new RegisterUserDto(null, null, "Tutor", null, null, null, null);
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(r => r.TutorDescription);
    }

    [Fact]
    public void Validate_ForInvalidTutorDescription_HasProperValidationError()
    {
        var model = new RegisterUserDto(null, null, "Tutor", null, null, null, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum euismod arcu eu sapien feugiat sollicitudin. Suspendisse in venenatis leo, ac mollis arcu. Aliquam facilisis metus blandit nisi egestas condimentum. Nunc quam nunc, fermentum vel ultrices sit amet, dictum sed velit. Praesent sollicitudin lectus non semper dictum. Vestibulum nulla justo, fringilla nec turpis sit amet, faucibus accumsan purus. Nam eros urna, sollicitudin at risus egestas, aliquam commodo velit. Sed eu ligula fusce.");
        var result = _emailNotTakenValidator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(r => r.TutorDescription);
    }
}
