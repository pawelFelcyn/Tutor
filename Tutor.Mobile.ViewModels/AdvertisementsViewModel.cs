using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class AdvertisementsViewModel : ViewModel
{
    private IAdvertisementsClient _advertisementsClient;

	[ObservableProperty]
	private AdvertisementDto test;

    public AdvertisementsViewModel(IAdvertisementsClient advertisementsClient)
	{
		Title = "Advertisements";
		_advertisementsClient = advertisementsClient;
		Advertisements = new();
	}

	public ObservableCollection<AdvertisementDto> Advertisements { get; set; }

	[RelayCommand]
	private async Task GetAdvertisementsAsync()
	{
		if (CheckIsBusy())
		{
			return;
		}

		try
		{
			var advertisementsResult = await _advertisementsClient.GetAdvertisementsAsync();

			if (Advertisements.Any())
			{
				Advertisements.Clear();
			}

			foreach (var advertisement in advertisementsResult.ContentDeserialized.Items)
			{
				Advertisements.Add(advertisement);
			}
			Test = Advertisements.First();
		}
		finally
		{
			IsBusy = false;
		}
	}
}
