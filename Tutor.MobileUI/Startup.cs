using Tutor.MobileUI.Pages;

namespace Tutor.MobileUI;

internal class Startup
{
    public static void OnAppInitialized(IServiceProvider serviceProvider)
    {
        var loginPage = serviceProvider.GetService<LoginPage>();

        if (loginPage is null)
        {
            throw new Exception("Login page has not been registered");
        }

        App.Current.MainPage = loginPage;
    }
}
