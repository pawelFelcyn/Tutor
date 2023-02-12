using Newtonsoft.Json;
using System.Net;

namespace Tutor.Client.APIAccess.Abstractions;

public class APIResponse
{
    protected APIResponse(HttpStatusCode statusCode, string contentString)
    {
        StatusCode = statusCode;
        ContentString = contentString;
    }

    public HttpStatusCode StatusCode { get; }
    public string ContentString { get; }

    public static async Task<APIResponse> FromHttpResponseMessageAsync(HttpResponseMessage response)
    {
        var contentString = await response.Content.ReadAsStringAsync();
        return new APIResponse(response.StatusCode, contentString);
    }
}

public class APIResponse<T> : APIResponse
{
    private APIResponse(HttpStatusCode statusCode, string contentString, T? contentDeserialized)
        : base(statusCode, contentString)
    {
        ContentDeserialized = contentDeserialized;
    }

    public T? ContentDeserialized { get; }

    public static async Task<APIResponse<TResponse>> FromHttpReponseMessageAsync<TResponse>(HttpResponseMessage response)
    {
        var contentString = await response.Content.ReadAsStringAsync();
        var contentDeserialized = JsonConvert.DeserializeObject<TResponse>(contentString);
        return new APIResponse<TResponse>(response.StatusCode, contentString, contentDeserialized);
    }
}
