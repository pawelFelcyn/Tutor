using Tutor.MobileUI.Pages;

namespace Tutor.MobileUI
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = new LoadingPage();
            Task.Run(() => Startup.OnAppInitialized(serviceProvider));
        }
    }
}