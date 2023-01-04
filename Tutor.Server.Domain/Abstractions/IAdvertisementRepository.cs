using Tutor.Server.Domain.Entities;

namespace Tutor.Server.Domain.Abstractions;

public interface IAdvertisementRepository : ICollectionMaterializingRepository<Advertisement>
{
    Task<Advertisement> AddAsync(Advertisement advertisement);
    Task<Advertisement> GetAsync(Guid id);
    IQueryable<Advertisement> GetAll();
    Task RemoveAsync(Advertisement advertisement);
}
