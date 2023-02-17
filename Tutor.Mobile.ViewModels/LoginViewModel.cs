using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using System.Net;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Client.Logic.Services;
using Tutor.Client.Logic.Static;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class LoginViewModel : ViewModel
{
	private readonly IValidator<LoginDto> _validator;
	private readonly ILoginClient _loginClient;
	private readonly ISecureStorage _secureStorage;
	private readonly IMainViewService _mainViewService;

	[ObservableProperty]
	private LoginDto _loginDto;
	[ObservableProperty]
	private string emailValidationErrors;
	[ObservableProperty]
	private string passwordValidationErrors;

	public LoginViewModel(IValidator<LoginDto> validator, ILoginClient loginClient,
		ISecureStorage secureStorage, IMainViewService mainViewService)
	{
		Title = "Login page";
		LoginDto = new(null, null);
        _validator = validator;
		_loginClient = loginClient;
		_secureStorage = secureStorage;
		_mainViewService = mainViewService;
    }

    [RelayCommand]
	private async Task LoginAsync()
	{
		if (CheckIsBusy())
		{
			return;
		}

		try
		{
			var validationResult = Validate(LoginDto, _validator);
			if (!validationResult.IsValid)
			{
				return;
			}

			var loginResult = await _loginClient.LoginAsync(LoginDto);
			await HandleLoginResultAsync(loginResult);
		}
		finally
		{
			IsBusy = false;
		}
	}

    private async Task HandleLoginResultAsync(APIResponse loginResult)
    {
		if (!loginResult.SuccesfullyCalledAPI)
		{
			await Shell.Current.DisplayAlert("Error", "Could't send login request. Try again laiter.", "Ok");
			return;
		}

		if (loginResult.StatusCode == HttpStatusCode.Unauthorized)
		{
			EmailValidationErrors = "Invalid email or password.";
			PasswordValidationErrors = "Invalid email or password.";
			return;
		}

		if (loginResult.StatusCode == HttpStatusCode.OK)
		{
			await _secureStorage.SetAsync(SecureStorageNames.Token, loginResult.ContentString);
			await _mainViewService.OpenMainViewAsync();
		}
    }

	[RelayCommand]
	private async Task OpenRegistrationPageAsync()
	{
		if (CheckIsBusy())
		{
			return;
		}

		try
		{
			await Shell.Current.GoToAsync("//Login/Register");
		}
		finally
		{
			IsBusy = false;
		}
	}
}