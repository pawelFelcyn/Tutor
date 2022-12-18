using AutoMapper;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services;

internal class AdvertisementService : IAdvertisementService
{
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;
    private readonly IAdvertisementRepository _repository;

    public AdvertisementService(IMapper mapper, IUserContextService userContextService,
        IAdvertisementRepository repository)
    {
        _mapper = mapper;
        _userContextService = userContextService;
        _repository = repository;
    }

    public async Task<AdvertisementDetailsDto> CreateAsync(CreateAdvertisementDto dto)
    {
        var advertisement = _mapper.Map<Advertisement>(dto);
        var now = DateTime.Now;
        advertisement.CreationDate = now;
        advertisement.LastModificationDate = now;
        advertisement.CreatedById = _userContextService.UserId.Value;
        advertisement = await _repository.AddAsync(advertisement);
        return _mapper.Map<AdvertisementDetailsDto>(advertisement);
    }
}
