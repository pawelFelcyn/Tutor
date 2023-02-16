using Tutor.Client.Logic.Services;

namespace Tutor.MobileUI.Services;

internal class MainViewService : IMainViewService
{
    private readonly IServiceProvider _serviceProvider;

    public MainViewService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task OpenMainViewAsync()
    {
        Application.Current.MainPage = _serviceProvider.GetRequiredService<AppShell>();
        return Task.CompletedTask;
    }
}
