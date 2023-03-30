using Tutor.Mobile.ViewModels;

namespace Tutor.MobileUI.Pages;

public partial class MyAdvertisementsPage : ContentPage
{
	public MyAdvertisementsPage(MyAdvertisementsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}