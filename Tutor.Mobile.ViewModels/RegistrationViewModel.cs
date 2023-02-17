using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class RegistrationViewModel : ViewModel
{
	private readonly IValidator<RegisterUserDto> _validator;

	[ObservableProperty]
	private RegisterUserDto _registerUserDto;
	[ObservableProperty]
	private int _selectedRoleIndex;
	[ObservableProperty]
	private string _firstNameValidationErrors;
	[ObservableProperty]
	private string _lastNameValidationErrors;
	[ObservableProperty]
	private string _roleValidationErrors;
	[ObservableProperty]
	private string _emailValidationErrors;
	[ObservableProperty]
	private string _passwordValidationErrors;
	[ObservableProperty]
	private string _confirmPasswordValidationErrors;
	[ObservableProperty]
	private string _tutorDescriptionValidationErrors;
	public string[] AllowedRoles { get; }

	public RegistrationViewModel(IValidator<RegisterUserDto> validator)
	{
		Title = "Registration";
		AllowedRoles = new string[] { "User", "Tutor" };
		RegisterUserDto = new(null, null, AllowedRoles[0], null, null, null, null);
		_validator = validator;
	}

    partial void OnSelectedRoleIndexChanged(int value)
    {
		var roleProperty = typeof(RegisterUserDto).GetProperty(nameof(RegisterUserDto.Role));
		roleProperty.SetValue(RegisterUserDto, AllowedRoles[value]);
    }

    [RelayCommand]
	private async Task ConfirmAsync()
	{
		if (CheckIsBusy())
		{
			return;
		}

		try
		{
			var validationResult = Validate(RegisterUserDto, _validator);
		}
		finally
		{
			IsBusy = false;
		}
	}
}
