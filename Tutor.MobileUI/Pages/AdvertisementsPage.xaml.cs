using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class AdvertisementsPage : ContentPage
{
	public AdvertisementsPage(AdvertisementsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}