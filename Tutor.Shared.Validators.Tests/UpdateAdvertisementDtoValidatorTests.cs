﻿using System.Runtime.Serialization.Json;
using Tutor.Shared.Enums;
using Tutor.Shared.Validators.Translations;

namespace Tutor.Shared.Validators.Tests;

public class UpdateAdvertisementDtoValidatorTests : ValidatorTests
{
	private readonly UpdateAdvertisementDtoValidator _validator;

	public UpdateAdvertisementDtoValidatorTests()
	{
		_validator = new(GetTranslator<UpdateAdvertisementDtoValidationMessage>());
	}

    public static IEnumerable<object[]> GetInvalidPrices()
    {
        yield return new object[] { 0 };
        yield return new object[] { -2 };
        yield return new object[] { -12313.23m };
        yield return new object[] { -12313.23123m };
    }

    [Fact]
	public void Validate_ForValidModel_DoesNotReturnAnyErrors()
	{
		var model = new UpdateAdvertisementDto("Test", "Test", 22.5m);
		var result = _validator.TestValidate(model);
		result.ShouldNotHaveAnyValidationErrors();
	}


    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("sadfdsfhsdkjfhkdjshfdjshfjhsdkjfhkjsdhfkjshdfsdhfjsdhfkdjsfhkdjshfkjhsdfjhdskfhkdjshfkdjshfsdkjfhkdjshfkdjshfkdjshfksdhkdjfhksfkjsfhkdsjfhkdjshfkdhsf")]
    public void Validate_ForInvalidTitle_ReturnsProperError(string title)
    {
        var model = new UpdateAdvertisementDto(title, "Test", 10);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.Title);
    }
    
    [Fact]
    public void Validate_ForInvalidDescription_ReturnsProperError()
    {
        var model = new UpdateAdvertisementDto("Title", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam lacus diam, faucibus nec eros ac, dapibus tempus magna. Curabitur fermentum nibh eget dictum congue. Maecenas vestibulum lectus felis, at accumsan augue blandit eget. Suspendisse vulputate eget dolor nec sodales. Fusce facilisis erat vel sapien pretium aliquet. Suspendisse scelerisque metus sem, nec sagittis quam faucibus sit amet. Praesent luctus sapien quis magna aliquet fringilla. Quisque a arcu ante. Donec nec porttitor nunc. Nunc elit ipsum, tincidunt eget interdum nec, elementum eget lacus. In non sapien ipsum. Nulla vitae pulvinar massa, ut malesuada elit. Suspendisse ac enim sed massa porttitor ultricies vitae sed turpis. Phasellus egestas tortor euismod nisl efficitur porttitor.\r\n\r\nDonec vel lectus sit amet purus viverra posuere. Aliquam a accumsan nisl. In hac habitasse platea dictumst. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aenean aliquam ultrices ex, a convallis nulla.", 40);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.Description);
    }

    [Theory]
    [MemberData(nameof(GetInvalidPrices))]
    public void Validate_ForInvalidPrice_ReturnsProperError(decimal price)
    {
        var model = new UpdateAdvertisementDto("Title", "Description", price);
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(m => m.PricePerHour);
    }
}
