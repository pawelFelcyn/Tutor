using CommunityToolkit.Mvvm.ComponentModel;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(CreateProfileImageDto), "ProfileImage")]
public partial class EditProfileViewModel : ViewModel
{
    [ObservableProperty]
    private CreateProfileImageDto _createProfileImageDto;

    public EditProfileViewModel()
    {
        Title = "Edit profile";
    }
}
