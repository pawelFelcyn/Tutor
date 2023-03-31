using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class AdvertisementDetailsPage : ContentPage
{
	public AdvertisementDetailsPage(AdvertisementDetailsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}