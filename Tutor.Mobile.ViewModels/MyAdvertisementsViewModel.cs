using Sieve.Models;
using System.Collections.ObjectModel;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;
using Tutor.Client.APIAccess.Abstractions.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Net;

namespace Tutor.Mobile.ViewModels;

public partial class MyAdvertisementsViewModel : ViewModel
{
    private readonly IAdvertisementClient _advertisementClient;
    [ObservableProperty]
    private bool successfulyLoadedAdvertisements = true;

    public MyAdvertisementsViewModel(IAdvertisementClient advertisementClient)
    {
        _advertisementClient = advertisementClient;
        Advertisements = new();
        Title = "My advertiseents";
        Task.Run(LoadAdvertisemets);
    }

    public ObservableCollection<AdvertisementDto> Advertisements { get; set; }

    private async Task LoadAdvertisemets()
    {
        if (CheckIsBusy())
        {
            return;
        }

        try
        {
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
