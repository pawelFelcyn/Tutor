using Tutor.MobileUI.Pages;

namespace Tutor.MobileUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("//MyAdvertisements/Details", typeof(AdvertisementDetailsPage));
        Routing.RegisterRoute("//MyAdvertisements/Details/Edit", typeof(EditAdvertisementPage));
    }
}