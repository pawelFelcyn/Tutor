using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess;

internal class SubjectClient : APIClient, ISubjectClient
{
    public SubjectClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<APIResponse<IEnumerable<SubjectDto>>> GetAll()
        => GetAsync<IEnumerable<SubjectDto>>("api/subjects");
}
