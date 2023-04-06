using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services.Abstractions;

public interface IImageService
{
    Task CreateAsync(CreateProfileImageDto dto);
}
