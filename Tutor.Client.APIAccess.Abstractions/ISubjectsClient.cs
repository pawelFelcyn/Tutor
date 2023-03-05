using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess.Abstractions;

public interface ISubjectsClient
{
    Task<APIResponse<IEnumerable<SubjectDto>>> GetSubjectAsync();
}
