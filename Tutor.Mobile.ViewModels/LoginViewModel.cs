using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class LoginViewModel : ViewModel
{
	private readonly IValidator<LoginDto> _validator;

	[ObservableProperty]
	private LoginDto _loginDto;
	[ObservableProperty]
	private string emailValidationErrors;
	[ObservableProperty]
	private string passwordValidationErrors;

	public LoginViewModel(IValidator<LoginDto> validator)
	{
		Title = "Login page";
		LoginDto = new(null, null);
        _validator = validator;
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
		}
		finally
		{
			IsBusy = false;
		}
	}
}
