using CommunityToolkit.Mvvm.ComponentModel;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(UserDetailsDto), "User")]
public partial class ProfileViewModel : ViewModel
{
    [ObservableProperty]
    private UserDetailsDto _userDetailsDto;

    public ProfileViewModel()
    {
        Title = "Profile";
    }
}
