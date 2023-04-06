using AutoMapper;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;
using Tutor.Shared.Exceptions;

namespace Tutor.Server.Application.Services;

internal class ImageService : IImageService
{
    private readonly IUserContextService _userContextService;
    private readonly IMapper _mapper;
    private readonly IImageRepository _imageRepository;

    public ImageService(IUserContextService userContextService, IMapper mapper,
        IImageRepository imageRepository)
    {
        _userContextService = userContextService;
        _mapper = mapper;
        _imageRepository = imageRepository;
    }

    public async Task CreateAsync(CreateProfileImageDto dto)
    {
        var userId = _userContextService.UserId.Value;
        var img = _mapper.Map<ProfileImage>(dto);
        img.UserId = userId;
        await _imageRepository.AddAsync(img);
    }
}
