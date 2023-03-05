using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Client.Models;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

public partial class AdvertisementsViewModel : ViewModel
{
    private IAdvertisementsClient _advertisementsClient;
	private readonly Shell _shell;
    private readonly ISubjectsClient _subjectsClient;

    [ObservableProperty]
	private AdvertisementsSieveModel _filterModel;
	private IEnumerable<SubjectDto> _subjects;

    public AdvertisementsViewModel(IAdvertisementsClient advertisementsClient,
		Shell shell, ISubjectsClient subjectsClient)
	{
		Title = "Advertisements";
		_advertisementsClient = advertisementsClient;
		_shell = shell;
		_subjectsClient = subjectsClient;
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
			if (_subjects is null && !await LoadSubjects())
			{
				await _shell.DisplayAlert("Error", "Couldn't load availible subjects. Try again later.", "Ok");
				return;
			}

			var parameters = new Dictionary<string, object>()
			{
				{ "FiltersModel", new AdvertisementsFilterModel(FilterModel, _subjects) }
			};
			await _shell.GoToAsync("//Advertisements/Filters", parameters);
		}
		finally
		{
			IsBusy = false;
		}
	}

    private async Task<bool> LoadSubjects()
    {
		var subjectsResponse = await _subjectsClient.GetSubjectAsync();

		if (!subjectsResponse.SuccesfullyCalledAPI || subjectsResponse.StatusCode != HttpStatusCode.OK)
		{
			_subjects = null;
			return false;
		}

		_subjects = subjectsResponse.ContentDeserialized;
		return true;
    }
}
