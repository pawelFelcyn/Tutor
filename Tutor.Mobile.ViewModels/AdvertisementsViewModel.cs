using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Client.Models;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class AdvertisementsViewModel : ViewModel
{
    private IAdvertisementsClient _advertisementsClient;
	private readonly Shell _shell;

	[ObservableProperty]
	private AdvertisementsFilterModel filterModel;

    public AdvertisementsViewModel(IAdvertisementsClient advertisementsClient,
		Shell shell)
	{
		Title = "Advertisements";
		_advertisementsClient = advertisementsClient;
		_shell = shell;
		Advertisements = new();
		FilterModel = new();
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
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	private async Task ModifyFiltersAsync()
	{
		if (CheckIsBusy())
		{
			return;
		}

		try
		{
			var parameters = new Dictionary<string, object>()
			{
				{ nameof(FilterModel), FilterModel }
			};
			await _shell.GoToAsync("//Advertisements/Filters", parameters);
		}
		finally
		{
			IsBusy = false;
		}
	}
}
