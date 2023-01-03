using Tutor.Server.Domain.Entities;

namespace Tutor.Server.Domain.Abstractions;

public interface IAdvertisementRepository
{
    Task<Advertisement> AddAsync(Advertisement advertisement);
    Task<Advertisement> GetAsync(Guid id);
    IQueryable<Advertisement> GetAll();
    Task<IEnumerable<Advertisement>> MaterializeAsync(IQueryable<Advertisement> query);
}
