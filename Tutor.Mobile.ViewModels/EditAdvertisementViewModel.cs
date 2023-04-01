using CommunityToolkit.Mvvm.ComponentModel;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(UpdateDto), "Model")]
public partial class EditAdvertisementViewModel : ViewModel
{
    [ObservableProperty]
    private UpdateAdvertisementDto _updateDto;

    public EditAdvertisementViewModel()
    {
        Title = "Edit";
    }
}
