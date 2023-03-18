using System.Globalization;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Client.Logic.Helpers;

internal class DeviceLocalizationInfoProvider : ILocalizationInfoProvider
{
    public string GetLocalizationInfo()
    {
        return CultureInfo.CurrentCulture.ToString();
    }
}
