using Tutor.Client.Logic.Services;
using Tutor.Client.Logic.Static;
using Tutor.Client.Maui.Extensions;
using Tutor.Shared.Dtos;

namespace Tutor.MobileUI.Services;

internal class LoggedUserContextService : ILoggedUserContextService
{
    private readonly IPreferences _preferences;

    public LoggedUserContextService(IPreferences preferences)
    {
        _preferences = preferences;
    }

    private UserDetailsDto _loggedUserDto;
    public UserDetailsDto LoggedInUser 
    { 
        get => _loggedUserDto ??= _preferences.GetFromJson<UserDetailsDto>(PreferencesNames.LoggedUser);
        set => _loggedUserDto = value; 
    }
}
