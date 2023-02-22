using Tutor.MobileUI.Pages;

namespace Tutor.MobileUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("//Advertisements/Filters", typeof(AdvertisementsFiltersPage));
        }
    }
}