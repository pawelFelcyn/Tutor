using System.Net.Http.Json;
using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess;

internal class APIClient
{
	protected readonly HttpClient _httpClient;
	private readonly BearerTokenFactory? _bearerTokenFactory;

	public APIClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

    public APIClient(HttpClient httpClient, BearerTokenFactory bearerTokenFactory)
		: this(httpClient)
    {
		_bearerTokenFactory = bearerTokenFactory;
    }

    protected async Task<APIResponse> PostAsync(string url, object content)
	{
		try
		{
			CreateToken();
			var response = await _httpClient.PostAsJsonAsync(url, content);
			return await APIResponse.FromHttpResponseMessageAsync(response);
		}
		catch (Exception e)
		{
			return APIResponse.Failure(e);
		}
	}

	protected async Task<APIResponse<T>> PostAsync<T>(string url, object content)
		where T : class
	{
        try
        {
            CreateToken();
            var response = await _httpClient.PostAsJsonAsync(url, content);
            return await APIResponse<T>.FromHttpResponseMessageAsync<T>(response);
        }
        catch (Exception e)
        {
            return APIResponse<T>.Failure<T>(e);
        }
    }

    private void CreateToken()
    {
		_httpClient.DefaultRequestHeaders.Authorization = null;
		if (_bearerTokenFactory is null)
		{
			return;
		}
		var token = _bearerTokenFactory();
		_httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);
    }

    protected async Task<APIResponse<T>> GetAsync<T>(string url, TutorSieveModel? sieve = default)
		where T : class
	{
		string? queryParams = sieve?.GetQueryString();

		try
		{
			CreateToken();
			var response = await _httpClient.GetAsync($"{url}?{queryParams ?? string.Empty}");
			return await APIResponse<T>.FromHttpResponseMessageAsync<T>(response);
		}
		catch (Exception e)
		{
			return APIResponse<T>.Failure<T>(e);
		}
	}

    protected async Task<APIResponse> GetAsync(string url)
    {
        try
        {
            CreateToken();
            var response = await _httpClient.GetAsync(url);
            return await APIResponse.FromHttpResponseMessageAsync(response);
        }
        catch (Exception e)
        {
            return APIResponse.Failure(e);
        }
    }

	protected async Task<APIResponse<T>> PatchAsync<T>(string url, object content)
		where T : class
	{
        try
        {
            CreateToken();
            var response = await _httpClient.PatchAsJsonAsync(url, content);
            return await APIResponse<T>.FromHttpResponseMessageAsync<T>(response);
        }
        catch (Exception e)
        {
            return APIResponse<T>.Failure<T>(e);
        }
    }
}
