using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using System.Net;
using System.Runtime.InteropServices;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(UpdateDto), "Model")]
[QueryProperty(nameof(AdvertisementId), "Id")]
[QueryProperty(nameof(UpdateCallback), "Callback")]
public partial class EditAdvertisementViewModel : ViewModel
{
    private readonly IValidator<UpdateAdvertisementDto> _validator;
    private readonly IAdvertisementClient _advertisementClient;
    private readonly INavigation _navigation;


    [ObservableProperty]
    private UpdateAdvertisementDto _updateDto;
    [ObservableProperty]
    private Guid _advertisementId;
    [ObservableProperty]
    private Action<AdvertisementDetailsDto> _updateCallback;
    [ObservableProperty]
    private string _titleValidationErrors;
    [ObservableProperty]
    private string _descriptionValidationErrors;
    [ObservableProperty]
    private string _pricePerHourValidationErrors;

    public EditAdvertisementViewModel(IValidator<UpdateAdvertisementDto> validaor,
        IAdvertisementClient advertisementClient, INavigation navigation)
    {
        _validator = validaor;
        _advertisementClient = advertisementClient;
        _navigation = navigation;
        Title = "Edit";
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (CheckIsBusy())
        {
            return;
        }

        try
        {
            var validationResult = Validate(UpdateDto, _validator);
            if (!validationResult.IsValid)
            {
                return;
            }
            var apiResponse = await _advertisementClient.UpdateAsync(AdvertisementId, UpdateDto);
            await HandleApiResponse(apiResponse);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task HandleApiResponse(APIResponse<AdvertisementDetailsDto> apiResponse)
    {
        if (!apiResponse.SuccesfullyCalledAPI
            || apiResponse.StatusCode != HttpStatusCode.OK)
        {
            await Shell.Current.DisplayAlert("Error", "Updating advertisement failed", "Ok");
            return;
        }

        await Shell.Current.DisplayAlert("Success", "Successfuly updated advertisement", "Ok");
        UpdateCallback?.Invoke(apiResponse.ContentDeserialized);
        await Shell.Current.GoToAsync("//MyAdvertisements/Details");
    }
}
