using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class LoginViewModel : ViewModel
{
	[ObservableProperty]
	private LoginDto _loginDto;

	public LoginViewModel()
	{
		Title = "Login page";
		LoginDto = new(null, null);
	}

	[RelayCommand]
	private Task LoginAsync()
	{
		return Task.CompletedTask;
	}
}
