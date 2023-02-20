using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}