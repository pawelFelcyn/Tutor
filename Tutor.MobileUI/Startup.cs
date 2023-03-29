using System.Net;
using Tutor.Client.APIAccess.Abstractions;
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

        MemoryStorage.Token = token;
        var refreshTokenClient = serviceProvider.GetRequiredService<IRefreshTokenClient>();
        var response = await refreshTokenClient.RefreshTokenAsync();
        if (response.StatusCode != HttpStatusCode.OK && response.SuccesfullyCalledAPI)
        {
            Application.Current.MainPage = startShell;
            return;
        }
        await secureStorage.SetAsync(SecureStorageNames.Token, response.ContentString);
        MemoryStorage.Token = response.ContentString;
        var mainViewService = serviceProvider.GetRequiredService<IMainViewService>();
        await mainViewService.OpenMainViewAsync();
    }
}
