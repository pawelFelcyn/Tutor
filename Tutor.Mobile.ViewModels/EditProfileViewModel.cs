using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(CreateProfileImageDto), "ProfileImage")]
public partial class EditProfileViewModel : ViewModel
{
    private readonly IMediaPicker _mediaPicker;

    [ObservableProperty]
    private CreateProfileImageDto _createProfileImageDto;

    public EditProfileViewModel(IMediaPicker mediaPicker)
    {
        _mediaPicker = mediaPicker;
        Title = "Edit profile";
    }

    [RelayCommand]
    private async Task UpdatePhotoAsync()
    {
        if (CheckIsBusy())
        {
            return;
        }

        try
        {
            string option = await GetTakingPhotoActionType();

            if (option is null || option == "Cancel")
            {
                return;
            }

            if (option == "Take a new photo")
            {
                await TakeNewPhoto();
                return;
            }

            if (option == "Select existing photo")
            {
                await SelectExistingPhoto();
            }
        }
        finally
        {
            IsBusy = false;
        }
    }

    private Task<string> GetTakingPhotoActionType()
    {
        return Shell.Current.DisplayActionSheet("What do you want to do?", "Cancel", null, "Take a new photo", "Select existing photo");
    }


    private async Task TakeNewPhoto()
    {
        var permissionStatus = await Permissions.RequestAsync<Permissions.Camera>();
        if (permissionStatus != PermissionStatus.Granted)
        {
            return;
        }

        var photo = await _mediaPicker.CapturePhotoAsync();
        await ReplaceProfileImageFromFile(photo);
    }

    private async Task ReplaceProfileImageFromFile(FileResult photo)
    {
        if (photo is null)
        {
            return;
        }

        var readBytes = await File.ReadAllBytesAsync(photo.FullPath);
        CreateProfileImageDto.Bytes = readBytes;
        OnPropertyChanged(nameof(CreateProfileImageDto));
    }

    private async Task SelectExistingPhoto()
    {
        var permissionStatus = await Permissions.RequestAsync<Permissions.Media>();
        if (permissionStatus != PermissionStatus.Granted)
        {
            return;
        }

        var photo = await _mediaPicker.PickPhotoAsync();
        await ReplaceProfileImageFromFile(photo);
    }
}
