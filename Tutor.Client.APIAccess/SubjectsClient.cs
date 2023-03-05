using Tutor.Client.APIAccess.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess;

internal class SubjectsClient : APIClient, ISubjectsClient
{
    public SubjectsClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<APIResponse<IEnumerable<SubjectDto>>> GetSubjectAsync() => await GetAsync<IEnumerable<SubjectDto>>("/api/subjects");
}
