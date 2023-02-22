using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class AdvertisementsFiltersPage : ContentPage
{
	public AdvertisementsFiltersPage(AdvertisementsFiltersViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}