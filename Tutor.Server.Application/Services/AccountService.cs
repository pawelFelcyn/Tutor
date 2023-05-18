using AutoMapper;
using Tutor.Server.Application.Services.Abstractions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services;

internal class AccountService : IAccountService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserContextService _userContextService;
    private readonly IMapper _mapper;
    private readonly IImageRepository _imageRepository;

    public AccountService(IUserRepository userRepository, IUserContextService userContextService,
        IMapper mapper, IImageRepository imageRepository)
    {
        _userRepository = userRepository;
        _userContextService = userContextService;
        _mapper = mapper;
        _imageRepository = imageRepository;
    }

    public async Task<UserDetailsDto> UpdateAsync(UpdateAccountDto dto)
    {
        var userId = _userContextService.UserId.Value;
        var user = await _userRepository.GetWithTutorAndImageAsync(userId);
        if (dto.UserData is not null) 
        {
            _mapper.Map(dto.UserData, user);
        }

        if (dto.ImageData is null && dto.RemoveImageIfNullGiven)
        {
            _imageRepository.Remove(user.PofileImage);
            user.PofileImage = null;
        }
        else if (dto.ImageData is not null)
        {
            _imageRepository.Remove(user.PofileImage);
            user.PofileImage = _mapper.Map<ProfileImage>(dto.ImageData);
        }
        await _userRepository.SaveChangesAsync();
        return _mapper.Map<UserDetailsDto>(user);
    }
}
