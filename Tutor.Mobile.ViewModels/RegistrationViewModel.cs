using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System.Net;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class RegistrationViewModel : ViewModel
{
	private readonly IValidator<RegisterUserDto> _validator;
	private readonly IRegistrationClient _registrationClient;

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

	public RegistrationViewModel(IValidator<RegisterUserDto> validator, IRegistrationClient registrationClient)
	{
		Title = "Registration";
		AllowedRoles = new string[] { "User", "Tutor" };
		RegisterUserDto = new(null, null, AllowedRoles[0], null, null, null, null);
		_validator = validator;
		_registrationClient = registrationClient;
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

			if (!validationResult.IsValid)
			{
				return;
			}
			var registrationResult = await _registrationClient.RegisterAsync(RegisterUserDto);
			await HandleRegistrtionResultAsync(registrationResult);
		}
		finally
		{
			IsBusy = false;
		}
	}

    private async Task HandleRegistrtionResultAsync(APIResponse registrationResult)
    {
		if (!registrationResult.SuccesfullyCalledAPI)
		{
			await Shell.Current.DisplayAlert("Error", "Couldn't send registration request. Try again later.", "Ok");
			return;
		}

		if (registrationResult.StatusCode == HttpStatusCode.BadRequest)
		{
			HandleValidationErrors(registrationResult);
			return;
		}


    }

    private void HandleValidationErrors(APIResponse registrationResult)
    {
        var errorsWrapper = JsonConvert.DeserializeObject<APIValidationErrorsWrapper>(registrationResult.ContentString);

		var failures = new List<ValidationFailure>();
		foreach (var pair in errorsWrapper.Errors)
		{
			foreach (var error in pair.Value)
			{
				failures.Add(new ValidationFailure(pair.Key, error));
			}
		}

		var validationResult = new ValidationResult(failures);
		HandleValidationResult(validationResult);
    }
}
