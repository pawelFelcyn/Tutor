using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Client.Logic.Helpers;
using Tutor.Shared.Dtos;
using Tutor.Shared.Enums;

namespace Tutor.Mobile.ViewModels;

public partial class CreateAdvertisementViewModel : ViewModel
{
    private readonly ISubjectClient _subjectClient;
    private readonly IAdvertisementClient _advertisementsClient;
    private readonly IIndexesToFlagsConverter _indexesToFlagsConverter;
    [ObservableProperty]
    private CreateAdvertisementDto _dto;
    [ObservableProperty]
    private SubjectDto _selectedSubject;

    public CreateAdvertisementViewModel(ISubjectClient subjectClient,
        IAdvertisementClient advertisementClient, IIndexesToFlagsConverter indexesToFlagsConverter)
    {
        _subjectClient = subjectClient;
        _advertisementsClient = advertisementClient;
        _indexesToFlagsConverter = indexesToFlagsConverter;
        Title = "Create advertisement";
        Dto = CreateAdvertisementDto.WithDefaultValues();
        Subjects = new();
        SelectedEducationLevelsIndexes = new();
        Task.Run(LoadSubjects);
    }

    public ObservableCollection<SubjectDto> Subjects { get; set; }
    public ObservableCollection<int> SelectedEducationLevelsIndexes { get; set; }

    private async Task LoadSubjects()
    {
        if (CheckIsBusy())
        {
            return;
        }

        try
        {
            var subjectsResponse = await _subjectClient.GetAll();
            if (!subjectsResponse.SuccesfullyCalledAPI
                || subjectsResponse.StatusCode != HttpStatusCode.OK)
            {
                await Shell.Current.DisplayAlert("Error", 
                    "Couldn't get subjects. Creating advertisement won't be possible", "Ok");
                return;
            }

            if (Subjects.Any())
            {
                Subjects.Clear();
            }

            foreach (var subject in subjectsResponse.ContentDeserialized)
            {
                Subjects.Add(subject);
            }
            SelectedSubject = Subjects.FirstOrDefault();
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task CreateAsync()
    {
        if (CheckIsBusy())
        {
            return;
        }


        try
        {
            Dto.Levels = _indexesToFlagsConverter.Convert<EducationLevels>(SelectedEducationLevelsIndexes);
            var apiResponse = await _advertisementsClient.CreateAsync(Dto);
            HandleCreateResponse(apiResponse);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void HandleCreateResponse(APIResponse<AdvertisementDetailsDto> apiResponse)
    {
        if (apiResponse.SuccesfullyCalledAPI && apiResponse.StatusCode == HttpStatusCode.Created)
        {
            Shell.Current.DisplayAlert("Success", "Advertisement created", "Ok");
        }
    }

    partial void OnSelectedSubjectChanged(SubjectDto value)
    {
        Dto.SubjectId = SelectedSubject?.Id ?? default;
    }
}
