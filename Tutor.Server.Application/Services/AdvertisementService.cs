using AutoMapper;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Tutor.Server.Application.Authentication;
using Tutor.Shared.Exceptions;

namespace Tutor.Server.Application.Services;

internal class AdvertisementService : IAdvertisementService
{
    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;
    private readonly IAdvertisementRepository _repository;
    private readonly IAuthorizationHandler _authorizationHandler;
    private readonly IAuthorizationContextProvider _authorizationContextProvider;

    public AdvertisementService(IMapper mapper, IUserContextService userContextService,
        IAdvertisementRepository repository, IAuthorizationHandler authorizationHandler,
        IAuthorizationContextProvider authorizationContextProvider)
    {
        _mapper = mapper;
        _userContextService = userContextService;
        _repository = repository;
        _authorizationHandler = authorizationHandler;
        _authorizationContextProvider = authorizationContextProvider;
    }

    public async Task<AdvertisementDetailsDto> CreateAsync(CreateAdvertisementDto dto)
    {
        var authorizationContext = _authorizationContextProvider.CreateContext(new RoleRequirement("Tutor"));
        await _authorizationHandler.HandleAsync(authorizationContext);

        if (!authorizationContext.HasSucceeded)
        {
            throw new CantCreateAdvertisementException();
        }

        var advertisement = _mapper.Map<Advertisement>(dto);
        var now = DateTime.Now;
        advertisement.CreationDate = now;
        advertisement.LastModificationDate = now;
        advertisement.CreatedById = _userContextService.UserId.Value;
        advertisement = await _repository.AddAsync(advertisement);
        return _mapper.Map<AdvertisementDetailsDto>(advertisement);
    }

    public async Task<AdvertisementDetailsDto> GetByIdAsync(Guid id)
    {
        var advertisement = await _repository.GetAsync(id);
        return _mapper.Map<AdvertisementDetailsDto>(advertisement);
    }
}
