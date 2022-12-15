using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Server.Infrastructure.Database;
using Tutor.Shared.Exceptions;

namespace Tutor.Server.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly TutorDbContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(TutorDbContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
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
                _logger.LogError(e, "Database exception");
                throw new LoggedException(e);
            }
        }
    }
}
