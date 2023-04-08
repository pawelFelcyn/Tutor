using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}