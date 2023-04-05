using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tutor.Client.Logic.Services;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(UpdateCallback), "Callback")]
public partial class AdvertisementDetailsViewModel : ViewModel
{
    private readonly ILoggedUserContextService _loggedUserContextService;

    [ObservableProperty]
    private AdvertisementDetailsDto _advertisement;
    [ObservableProperty]
    private Action<AdvertisementDetailsDto> _updateCallback;

    public AdvertisementDetailsViewModel(ILoggedUserContextService loggedUserContextService)
    {
        _loggedUserContextService = loggedUserContextService;
        Title = "Details";
    }

    [RelayCommand]
    private async Task EditAsync()
    {
        if (CheckIsBusy())
        {
            return;
        }

        try
        {
            if (_loggedUserContextService.LoggedInUser.Id != Advertisement.CreatedById)
            {
                return;
            }

            var updateModel = UpdateAdvertisementDto.FromDetails(Advertisement);
            Action<AdvertisementDetailsDto> callback = d =>
            {
                Advertisement = d;
                UpdateCallback?.Invoke(d);
            };
            var parameters = new Dictionary<string, object>()
            {
                { "Model", updateModel },
                { "Id", Advertisement.Id },
                { "Callback", callback }
            };
            await Shell.Current.GoToAsync("//MyAdvertisements/Details/Edit", parameters);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
