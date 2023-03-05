using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tutor.Client.Models;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(Model), "FiltersModel")]
public partial class AdvertisementsFiltersViewModel : ViewModel
{
	[ObservableProperty]
	private AdvertisementsFilterModel _model;
	[ObservableProperty]
	private SubjectDto _selectedSubject;

	public AdvertisementsFiltersViewModel()
	{
		Title = "Filters";
	}

    partial void OnModelChanged(AdvertisementsFilterModel value)
    {
		SelectedSubject = value?.AllSubjects.FirstOrDefault(s => s.Id == value.Filters?.Subject);
    }

    partial void OnSelectedSubjectChanged(SubjectDto value)
    {
		Model.Filters.Subject = value.Id;
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
