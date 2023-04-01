using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class EditAdvertisementPage : ContentPage
{
	public EditAdvertisementPage(EditAdvertisementViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}