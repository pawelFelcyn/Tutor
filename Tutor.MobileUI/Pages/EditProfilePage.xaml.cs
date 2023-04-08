using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePage(EditProfileViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}