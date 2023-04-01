using Newtonsoft.Json;

namespace Tutor.Client.Maui.Extensions;

public static class PreferencesExtensions
{
    public static void SetAsJson<T>(this IPreferences preferences, string key, T value)
        where T : class
    {
        Nullcheck(preferences);

        var json = JsonConvert.SerializeObject(value);
        preferences.Set(key, json);
    }

    private static void Nullcheck(IPreferences preferences)
    {
        if (preferences is null)
        {
            throw new ArgumentNullException(nameof(preferences));
        }
    }

    public static T GetFromJson<T>(this IPreferences preferences, string key)
        where T : class
    {
        Nullcheck(preferences);

        var json = preferences.Get(key, default(string));

        if (json is null)
        {
            return null;
        }

        return JsonConvert.DeserializeObject<T>(json);
    }
}
