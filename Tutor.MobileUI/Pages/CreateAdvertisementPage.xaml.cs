using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class CreateAdvertisementPage : ContentPage
{
	public CreateAdvertisementPage(CreateAdvertisementViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}