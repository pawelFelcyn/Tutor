using System.Security.Cryptography;

namespace Tutor.Shared.Dtos;

public record UpdateAdvertisementDto(string Title, string Description, decimal PricePerHour)
{
    public static UpdateAdvertisementDto FromDetails(AdvertisementDetailsDto details)
        => new(details.Title, details.Description, details.PricePerHour);
}