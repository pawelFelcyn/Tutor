using AutoMapper;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Tutor.Server.Application.Authentication;
using Tutor.Shared.Exceptions;
using Sieve.Models;
using Sieve.Services;

namespace Tutor.Server.Application.Services;

internal class AdvertisementService : IAdvertisementService
{
    private const int DEFAULT_PAGE_SIZE = 15;

    private readonly IMapper _mapper;
    private readonly IUserContextService _userContextService;
    private readonly IAdvertisementRepository _repository;
    private readonly IAuthorizationHandler _authorizationHandler;
    private readonly IAuthorizationContextProvider _authorizationContextProvider;
    private readonly ISieveProcessor _sieveProcessor;

    public AdvertisementService(IMapper mapper, IUserContextService userContextService,
        IAdvertisementRepository repository, IAuthorizationHandler authorizationHandler,
        IAuthorizationContextProvider authorizationContextProvider, ISieveProcessor sieveProcessor)
    {
        _mapper = mapper;
        _userContextService = userContextService;
        _repository = repository;
        _authorizationHandler = authorizationHandler;
        _authorizationContextProvider = authorizationContextProvider;
        _sieveProcessor = sieveProcessor;
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

    public async Task<PagedResult<AdvertisementDto>> GetAllAsync(SieveModel query)
    {
        ApplyDefaultValues(query);

        var advertisements =  _repository.GetAll();
        var totalCount = advertisements.Count();
        advertisements = _sieveProcessor.Apply(query, advertisements);
        var mappedAdvertisements = _mapper.Map<List<AdvertisementDto>>(await _repository.MaterializeAsync(advertisements));
        return new PagedResult<AdvertisementDto>(mappedAdvertisements, totalCount, query.PageSize.Value, query.Page.Value);
    }

    private void ApplyDefaultValues(SieveModel query)
    {
        query.PageSize ??= DEFAULT_PAGE_SIZE;
        query.Page ??= 1;
    }
}
