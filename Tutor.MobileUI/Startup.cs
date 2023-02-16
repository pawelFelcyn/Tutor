using Tutor.MobileUI.Pages;

namespace Tutor.MobileUI;

internal class Startup
{
    public static void OnAppInitialized(IServiceProvider serviceProvider)
    {
        var startShell = serviceProvider.GetService<StartShell>();

        if (startShell is null)
        {
            throw new Exception("Start shell has not been registered");
        }

        App.Current.MainPage = startShell;
    }
}
