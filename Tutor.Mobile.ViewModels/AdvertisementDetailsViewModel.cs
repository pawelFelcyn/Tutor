using CommunityToolkit.Mvvm.ComponentModel;
using Tutor.Shared.Dtos;

namespace Tutor.Mobile.ViewModels;

[QueryProperty(nameof(Advertisement), "Advertisement")]
public partial class AdvertisementDetailsViewModel : ViewModel
{
    [ObservableProperty]
    private AdvertisementDetailsDto _advertisement;

    public AdvertisementDetailsViewModel()
    {
        Title = "Details";
    }

    partial void OnAdvertisementChanged(AdvertisementDetailsDto value)
    {
        return;
    }
}
