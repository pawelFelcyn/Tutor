using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Server.Application.Helpers;

internal class HeaderLocalizationInfoProvider : ILocalizationInfoProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HeaderLocalizationInfoProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetLocalizationInfo()
    {
        var found = _httpContextAccessor.HttpContext.Request.Headers.TryGetValue("locale-info", out StringValues values);
        if (!found || !values.Any()) 
        {
            return "en-US";
        }

        return values.FirstOrDefault();
    }
}
