using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System.Net;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Client.Logic.Services;
using Tutor.Client.Logic.Static;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class RegistrationViewModel : ViewModel
{
	private readonly IValidator<RegisterUserDto> _validator;
	private readonly IRegistrationClient _registrationClient;
	private readonly ILoginClient _loginClient;
	private readonly ISecureStorage _secureStorage;
	private readonly INavigation _navigation;
	private readonly IMainViewService _mainViewService;

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

	public RegistrationViewModel(IValidator<RegisterUserDto> validator, IRegistrationClient registrationClient,
		ILoginClient loginClient, ISecureStorage secureStorage, INavigation navigation,
		IMainViewService mainViewService)
	{
		Title = "Registration";
		AllowedRoles = new string[] { "User", "Tutor" };
		RegisterUserDto = new(null, null, AllowedRoles[0], null, null, null, null);
		_validator = validator;
		_registrationClient = registrationClient;
		_loginClient = loginClient;
		_secureStorage = secureStorage;
		_navigation = navigation;
		_mainViewService = mainViewService;
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

		if (registrationResult.StatusCode == HttpStatusCode.OK)
		{
			await LoginWithRegisteredCredentialsAsync();
			return;
		}

		await Shell.Current.DisplayAlert("Error", "Registration failed, try again later.", "Ok");
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

	private async Task LoginWithRegisteredCredentialsAsync()
	{
		var loginResult = await _loginClient.LoginAsync(new LoginDto(RegisterUserDto.Email, RegisterUserDto.Password));

		if (!loginResult.SuccesfullyCalledAPI
			|| loginResult.StatusCode != HttpStatusCode.OK)
		{
			await Shell.Current.DisplayAlert("Error", "Successfuly created an account, but login failed. Try sign in later.", "Ok");
			await _navigation.PopAsync();
			return;
		}

		await _secureStorage.SetAsync(SecureStorageNames.Token, loginResult.ContentString);
		await _mainViewService.OpenMainViewAsync();
	}
}
