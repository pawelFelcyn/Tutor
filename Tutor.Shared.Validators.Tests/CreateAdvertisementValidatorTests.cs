using Tutor.Shared.Enums;

namespace Tutor.Shared.Validators.Tests;

public class CreateAdvertisementValidatorTests 
{
    private CreateAdvertisementDtoValidator _validator;

    public CreateAdvertisementValidatorTests()
	{
		_validator = new();
	}

	[Fact]
	public void Validate_ForValidModel_DoesNotReturnErrors()
	{
		var model = new CreateAdvertisementDto("Title", "Description", EducationLevels.Primary, Subject.English, 40);
		var result = _validator.TestValidate(model);
		result.ShouldNotHaveAnyValidationErrors();
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("sadfdsfhsdkjfhkdjshfdjshfjhsdkjfhkjsdhfkjshdfsdhfjsdhfkdjsfhkdjshfkjhsdfjhdskfhkdjshfkdjshfsdkjfhkdjshfkdjshfkdjshfksdhkdjfhksfkjsfhkdsjfhkdjshfkdhsf")]
	public void Validate_ForInvalidTitle_ReturnsProperError(string title)
	{
		var model = new CreateAdvertisementDto(title, "Description", EducationLevels.Primary, Subject.English, 40);
        var result = _validator.TestValidate(model);
		result.ShouldHaveValidationErrorFor(m => m.Title);
    }
}
