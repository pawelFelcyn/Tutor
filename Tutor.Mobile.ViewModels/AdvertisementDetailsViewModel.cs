using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tutor.Client.Logic.Services;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(Advertisement), "Advertisement")]
public partial class AdvertisementDetailsViewModel : ViewModel
{
    private readonly ILoggedUserContextService _loggedUserContextService;
    private readonly INavigation _navigation;

    [ObservableProperty]
    private AdvertisementDetailsDto _advertisement;

    public AdvertisementDetailsViewModel(ILoggedUserContextService loggedUserContextService,
        INavigation navigation)
    {
        _loggedUserContextService = loggedUserContextService;
        _navigation = navigation;
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

            await Shell.Current.GoToAsync("//MyAdvertisements/Details/Edit");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
