using Tutor.Client.Logic.Services;
using Tutor.Client.Logic.Static;
using Tutor.MobileUI.Pages;

namespace Tutor.MobileUI;

internal class Startup
{
    public static async Task OnAppInitialized(IServiceProvider serviceProvider)
    {
        var startShell = serviceProvider.GetService<StartShell>();

        if (startShell is null)
        {
            throw new Exception("Start shell has not been registered");
        }

        var secureStorage = serviceProvider.GetRequiredService<ISecureStorage>();
        var token = await secureStorage.GetAsync(SecureStorageNames.Token);
        if (token is null) 
        {
            Application.Current.MainPage = startShell;
            return;
        }

        var mainViewService = serviceProvider.GetRequiredService<IMainViewService>();
        await mainViewService.OpenMainViewAsync();
    }
}
