using DevExpress.Maui;
using Microsoft.Extensions.Logging;
using Tutor.Mobile.ViewModels;
using Tutor.MobileUI.Pages;
using Tutor.Shared.Validators;
using Tutor.Client.Logic;
using Tutor.Client.Logic.Services;
using Tutor.MobileUI.Services;
using Tutor.Client.APIAccess;
using System.Globalization;
using Tutor.Client.Logic.Static;

namespace Tutor.MobileUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder
                .Services
                .AddTransient<LoginPage>()
                .AddTransient<LoginViewModel>()
                .AddValidators()
                .AddLogic()
                .AddScoped<IMainViewService, MainViewService>()
                .AddAPIAccess()
                .AddSingleton(GetHttpClient())//this should be done in some other way in the future, I should use HttpClientFactory
                .AddScoped(_ => SecureStorage.Default)
                .AddTransient<AppShell>()
                .AddTransient<StartShell>()
                .AddTransient<RegistrationPage>()
                .AddTransient<RegistrationViewModel>()
                .AddScoped(_ => Shell.Current.Navigation)
                .AddScoped<CreateAdvertisementPage>()
                .AddScoped<CreateAdvertisementViewModel>()
                .AddScoped<BearerTokenFactory>(_ => () => MemoryStorage.Token)
                .AddScoped<MyAdvertisementsPage>();

            return builder.Build();
        }

        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://10.0.2.2:5000"),
                Timeout = TimeSpan.FromSeconds(10),
            };

            client.DefaultRequestHeaders.Add("locale-info", CultureInfo.CurrentCulture.ToString());

            return client;
        }
    }
}