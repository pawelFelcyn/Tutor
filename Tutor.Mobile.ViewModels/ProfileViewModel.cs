using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tutor.Client.Logic.Services;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(UserDetailsDto), "User")]
public partial class ProfileViewModel : ViewModel
{
    private readonly ILoggedUserContextService _loggedUserContextService;
    [ObservableProperty]
    private UserDetailsDto _userDetailsDto;

    public ProfileViewModel(ILoggedUserContextService loggedUserContextService)
    {
        _loggedUserContextService = loggedUserContextService;
        Title = "Profile";
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
            if (_loggedUserContextService.LoggedInUser.Id != UserDetailsDto.Id)
            {
                return;
            }

            var parameters = new Dictionary<string, object>
            {
                { "ProfileImage", new CreateProfileImageDto(UserDetailsDto.ProfileImage) }
            };

            await Shell.Current.GoToAsync("//Main/MyProfile/Edit", parameters);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
