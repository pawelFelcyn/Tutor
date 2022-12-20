using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services.Abstractions;

public interface IAdvertisementService
{
    Task<AdvertisementDetailsDto> CreateAsync(CreateAdvertisementDto dto);
    Task<AdvertisementDetailsDto> GetByIdAsync(Guid id);
}
