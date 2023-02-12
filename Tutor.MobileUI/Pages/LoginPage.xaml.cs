using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}