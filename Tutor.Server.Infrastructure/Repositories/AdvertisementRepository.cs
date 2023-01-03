using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Server.Infrastructure.Database;
using Tutor.Shared.Exceptions;

namespace Tutor.Server.Infrastructure.Repositories;

internal class AdvertisementRepository : RepositoryBase, IAdvertisementRepository
{
    public AdvertisementRepository(TutorDbContext dbContext, ILogger<AdvertisementRepository> logger) 
        : base(dbContext, logger)
    {
    }

    public async Task<Advertisement> AddAsync(Advertisement advertisement)
    {
        try
        {
            await _dbContext.AddAsync(advertisement);
            await _dbContext.SaveChangesAsync();
            return advertisement;
        }
        catch (Exception e)
        {
            LogAndThrow(e);
            throw new UnreachableException();
        }
    }

    public async Task<Advertisement> GetAsync(Guid id)
    {
        try
        {
            var advertisement = await _dbContext.Advertisements.FirstOrDefaultAsync(a => a.Id == id);

            if (advertisement is null)
            {
                throw new AdvertisementNotFoundException(id);
            }

            return advertisement;
        }
        catch (AdvertisementNotFoundException)
        {
            throw;
        }
        catch (Exception e)
        {
            LogAndThrow(e);
            throw new UnreachableException();
        }
    }


    public IQueryable<Advertisement> GetAll()
    {
        return _dbContext.Advertisements;
    }

    public async Task<IEnumerable<Advertisement>> MaterializeAsync(IQueryable<Advertisement> query)
    {
        try
        {
            return await query.ToListAsync();
        }
        catch (Exception e)
        {
            LogAndThrow(e);
            throw new UnreachableException();
        }
    }
}
