using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq.Expressions;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Server.Infrastructure.Database;
using Tutor.Shared.Exceptions;

namespace Tutor.Server.Infrastructure.Repositories;

internal class UserRepository : RepositoryBase, IUserRepository
{
    public UserRepository(TutorDbContext dbContext, ILogger<UserRepository> logger)
        : base(dbContext, logger)
    {
    }

    public async Task AddAsync(User user)
    {
        try
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            LogAndThrow(e);
        }
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await GetByPredicate(u => u.Email == email);
    }

    private async Task<User> GetByPredicate(Expression<Func<User, bool>> predicate, Func<IQueryable<User>, IQueryable<User>> queryBuilder = null)
    {
        if (predicate is  null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        try
        {
            IQueryable<User> query = _dbContext.Users;

            if (queryBuilder is not null)
            {
                query = queryBuilder(query);
            }

            var user = await query.FirstOrDefaultAsync(predicate);
            if (user is null)
            {
                throw new InvalidEmailException();
            }
            return user;
        }
        catch (InvalidEmailException)
        {
            throw;
        }
        catch (Exception e)
        {
            LogAndThrow(e);
            throw new UnreachableException();
        }
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await GetByPredicate(u => u.Id == id);
    }

    public async Task<User> GetWithTutorAndImageAsync(Guid id)
    {
        return await GetByPredicate(u => u.Id == id, q => q.Include(u => u.Tutor).Include(u => u.PofileImage));
    }
}
