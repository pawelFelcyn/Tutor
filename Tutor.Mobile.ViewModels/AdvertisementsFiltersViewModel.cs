using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tutor.Client.Models;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(OriginalFilters), nameof(AdvertisementsViewModel.FilterModel))]
public partial class AdvertisementsFiltersViewModel : ViewModel
{
	[ObservableProperty]
	private AdvertisementsFilterModel originalFilters;
	[ObservableProperty]
	private AdvertisementsFilterModel filterModel;

	public AdvertisementsFiltersViewModel()
	{
		Title = "Filters";
	}

    partial void OnOriginalFiltersChanged(AdvertisementsFilterModel value)
    {
		FilterModel = value is null ? null : (AdvertisementsFilterModel)value.Clone();
    }


    [RelayCommand]
	private async Task SaveChangesAsync()
	{

	}

	[RelayCommand]
	private async Task DiscardChangedAsync()
	{

	}
}
