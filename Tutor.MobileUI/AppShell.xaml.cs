using Tutor.Mobile.ViewModels;
using Tutor.MobileUI.Pages;

namespace Tutor.MobileUI;

public partial class AppShell : Shell
{
    public AppShell(AppViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
        Routing.RegisterRoute("//MyAdvertisements/Details", typeof(AdvertisementDetailsPage));
        Routing.RegisterRoute("//MyAdvertisements/Details/Edit", typeof(EditAdvertisementPage));
        Routing.RegisterRoute("//Main/MyProfile", typeof(ProfilePage));
        Routing.RegisterRoute("//Main/MyProfile/Edit", typeof(EditProfilePage));
    }
}