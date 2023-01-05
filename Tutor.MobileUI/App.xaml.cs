using Tutor.MobileUI.Pages;

namespace Tutor.MobileUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new LoadingPage();
        }
    }
}