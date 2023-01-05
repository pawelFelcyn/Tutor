using AutoMapper;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services;

internal class SubjectsService : ISubjectService
{
    private readonly ISubjectRepository _repository;
    private readonly IMapper _mapper;

    public SubjectsService(ISubjectRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SubjectDto>> GetAll()
    {
        var subjects = await _repository.MaterializeAsync(_repository.GetAll());
        return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
    }
}
