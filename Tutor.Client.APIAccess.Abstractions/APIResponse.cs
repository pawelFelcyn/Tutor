using Newtonsoft.Json;
using System.Net;

namespace Tutor.Client.APIAccess.Abstractions;

public class APIResponse
{
    protected APIResponse(HttpStatusCode statusCode, string? contentString, Exception? e = default)
    {
        StatusCode = statusCode;
        ContentString = contentString;
        Exception = e;
    }

    public HttpStatusCode StatusCode { get; }
    public string? ContentString { get; }
    public Exception? Exception { get; }
    public bool SuccesfullyCalledAPI => Exception is null;

    public static async Task<APIResponse> FromHttpResponseMessageAsync(HttpResponseMessage response)
    {
        var contentString = await response.Content.ReadAsStringAsync();
        return new APIResponse(response.StatusCode, contentString);
    }

    public static APIResponse Failure(Exception e)
    {
        return new APIResponse(default, default, e);
    }
}

public class APIResponse<T> : APIResponse
{
    private APIResponse(HttpStatusCode statusCode, string? contentString, T? contentDeserialized,
        Exception? e = default)
        : base(statusCode, contentString, e)
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

    public static APIResponse<TResponse> Failure<TResponse>(Exception e)
    {
        return new APIResponse<TResponse>(default, default, default, e);
    }
}
