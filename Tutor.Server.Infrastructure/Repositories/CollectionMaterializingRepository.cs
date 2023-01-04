using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Infrastructure.Database;

namespace Tutor.Server.Infrastructure.Repositories;

internal class CollectionMaterializingRepository<T> : RepositoryBase, ICollectionMaterializingRepository<T>
    where T : class
{
    public CollectionMaterializingRepository(TutorDbContext dbContext, ILogger<RepositoryBase> logger) 
        : base(dbContext, logger)
    {
    }

    public async Task<IEnumerable<T>> MaterializeAsync(IQueryable<T> query)
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
