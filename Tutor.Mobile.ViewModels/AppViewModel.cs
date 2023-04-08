using CommunityToolkit.Mvvm.Input;
using Tutor.Client.Logic.Services;

namespace Tutor.Mobile.ViewModels;

public partial class AppViewModel : ViewModel
{
    private readonly ILoggedUserContextService _loggedUserContextService;

    public AppViewModel(ILoggedUserContextService loggedUserContextService)
    {
        _loggedUserContextService = loggedUserContextService;
    }

    [RelayCommand]
    private async Task GoToMyProfileAsync()
    {
        if (CheckIsBusy())
        {
            return;
        }

        try
        {
            var user = _loggedUserContextService.LoggedInUser;
            var parameters = new Dictionary<string, object>()
            {
                { "User", user }
            };
            Shell.Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync("//Main/MyProfile", parameters);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
