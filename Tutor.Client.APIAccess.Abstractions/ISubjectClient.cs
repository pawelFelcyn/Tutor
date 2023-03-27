using Tutor.Shared.Dtos;

namespace Tutor.Client.APIAccess.Abstractions;

public interface ISubjectClient
{
    Task<APIResponse<IEnumerable<SubjectDto>>> GetAll();
}
