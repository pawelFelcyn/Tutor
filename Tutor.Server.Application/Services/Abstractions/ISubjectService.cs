using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services.Abstractions;

public interface ISubjectService
{
    Task<IEnumerable<SubjectDto>> GetAll();
}
