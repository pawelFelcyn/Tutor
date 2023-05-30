using AutoMapper;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Tutor.Server.Application.Authentication;
using Tutor.Shared.Exceptions;

namespace Tutor.Server.Application.Services;

internal class AdvertisementService : ServiceBase, IAdvertisementService
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

    public async Task<PagedResult<AdvertisementDto>> GetAllAsync(AdvertisementsSieveModel query)
    {
        var advertisements = _repository.GetAll();
        advertisements = ApplyCustomFilters(query, advertisements);
        advertisements = ApplyPages(advertisements, query);
        var totalCount = advertisements.Count();
        var mappedAdvertisements = _mapper.Map<List<AdvertisementDto>>(await _repository.MaterializeAsync(advertisements));
        return new PagedResult<AdvertisementDto>(mappedAdvertisements, totalCount, query.PageSize, query.PageNumber);
    }

    private IQueryable<Advertisement> ApplyCustomFilters(AdvertisementsSieveModel query, IQueryable<Advertisement> advertisements)
    {
        if (query.CreatedByClientOnly)
        {
            advertisements = ApplyAuthorFilter(ref advertisements);
        }

        if (!string.IsNullOrEmpty(query.Title))
        {
            advertisements = advertisements.Where(a => a.Title.Contains(query.Title));
        }

        if (query.SelectedSubject.HasValue)
        {
            advertisements = advertisements.Where(a => a.SubjectId ==  query.SelectedSubject.Value);
        }

        if (query.MinPrice.HasValue)
        {
            advertisements = advertisements.Where(a => a.PricePerHour >= query.MinPrice.Value);
        }

        if (query.MaxPrice.HasValue) 
        {
            advertisements = advertisements.Where(a => a.PricePerHour <= query.MaxPrice.Value);
        }

        return advertisements;
    }

    private IQueryable<Advertisement> ApplyAuthorFilter(ref IQueryable<Advertisement> advertisements)
    {
        if (_userContextService.User is null)
        {
            throw new InvalidQueryException(nameof(AdvertisementsSieveModel.CreatedByClientOnly));
        }

        advertisements = advertisements.Where(a => a.CreatedById == _userContextService.UserId);
        return advertisements;
    }

    public async Task DeleteAsync(Guid id)
    {
        var advertisement = await _repository.GetAsync(id);
        var authorizationContext = _authorizationContextProvider.CreateContext(new UserIdRequirement(advertisement.CreatedById));
        await _authorizationHandler.HandleAsync(authorizationContext);

        if (!authorizationContext.HasSucceeded)
        {
            throw new CantDeleteAdvertisementException();
        }

        await _repository.RemoveAsync(advertisement);
    }

    public async Task<AdvertisementDetailsDto> UpdateAsync(Guid id, UpdateAdvertisementDto dto)
    {
        var advertisement = await _repository.GetAsync(id);
        var authorizationContext = _authorizationContextProvider.CreateContext(new UserIdRequirement(advertisement.CreatedById));
        await _authorizationHandler?.HandleAsync(authorizationContext);

        if (!authorizationContext.HasSucceeded)
        {
            throw new CantUpdateAdvertisementException();
        }

        _mapper.Map(dto, advertisement);
        await _repository.SaveChangesAsync();

        return _mapper.Map<AdvertisementDetailsDto>(advertisement);
    }
}
