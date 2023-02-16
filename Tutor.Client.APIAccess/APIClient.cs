using Newtonsoft.Json;
using System.Net.Http.Json;
using Tutor.Client.APIAccess.Abstractions;

namespace Tutor.Client.APIAccess;

internal class APIClient
{
	protected readonly HttpClient _httpClient;

	public APIClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	protected async Task<APIResponse> PostAsync(string url, object content)
	{
		try
		{
			var response = await _httpClient.PostAsJsonAsync(url, content);
			return await APIResponse.FromHttpResponseMessageAsync(response);
		}
		catch (Exception e)
		{
			return APIResponse.Failure(e);
		}
	}
}
