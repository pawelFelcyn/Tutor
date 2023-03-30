using Sieve.Models;
using System.Collections.ObjectModel;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;
using Tutor.Client.APIAccess.Abstractions.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Net;
using CommunityToolkit.Mvvm.Input;

namespace Tutor.Mobile.ViewModels;

public partial class MyAdvertisementsViewModel : ViewModel
{
    private readonly IAdvertisementClient _advertisementClient;
    [ObservableProperty]
    private bool _successfulyLoadedAdvertisements = true;
    [ObservableProperty]
    private bool _isRefreshing;

    public MyAdvertisementsViewModel(IAdvertisementClient advertisementClient)
    {
        _advertisementClient = advertisementClient;
        Advertisements = new();
        Title = "My advertisements";
        Task.Run(LoadAdvertisementsAsync);
    }

    public ObservableCollection<AdvertisementDto> Advertisements { get; set; }

    [RelayCommand]
    private async Task LoadAdvertisementsAsync()
    {
        if (CheckIsBusy())
        {
            return;
        }

        try
        {
            IsRefreshing = true;
            Advertisements.Clear();
            var apiResponse = await _advertisementClient.GetAllAsync(s => s.CreatedByClientOnly = true);
            HandleGetAdvertisementsResult(apiResponse);
        }
        catch
        {
            SuccessfulyLoadedAdvertisements = false;
        }
        finally
        {
            IsRefreshing = false;
            IsBusy = false;
        }
    }

    private void HandleGetAdvertisementsResult(APIResponse<PagedResult<AdvertisementDto>> apiResponse)
    {
        if (!apiResponse.SuccesfullyCalledAPI || 
            apiResponse.StatusCode != HttpStatusCode.OK)
        {
            SuccessfulyLoadedAdvertisements = false;
            return;
        }

        foreach (var ad in apiResponse.ContentDeserialized.Items)
        {
            Advertisements.Add(ad);
        }
    }
}
