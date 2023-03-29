using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
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
        try
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
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
        try
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
            {
                throw new UserNotFoundException(id);
            }
            return user;
        }
        catch (UserNotFoundException)
        {
            throw;
        }
        catch (Exception e)
        {
            LogAndThrow(e);
            throw new UnreachableException();
        }
    }
}
