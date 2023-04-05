using Tutor.Mobile.ViewModels;
using Tutor.Shared.Dtos;

namespace Tutor.MobileUI.Pages;

public partial class AdvertisementDetailsPage : ContentPage, IQueryAttributable
{
	private readonly AdvertisementDetailsViewModel _viewModel;

	public AdvertisementDetailsPage(AdvertisementDetailsViewModel viewModel)
	{
		_viewModel = viewModel;
		BindingContext = viewModel;
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
		if (query.TryGetValue("Advertisement", out var a))
		{
			_viewModel.Advertisement = a as AdvertisementDetailsDto;
		}
    }
}