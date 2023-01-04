using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Infrastructure.Database;
using Tutor.Shared.Exceptions;

namespace Tutor.Server.Infrastructure.Repositories
{
    internal abstract class RepositoryBase : IRepository
    {
        protected readonly TutorDbContext _dbContext;
        protected readonly ILogger<RepositoryBase> _logger;

        public RepositoryBase(TutorDbContext dbContext, ILogger<RepositoryBase> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected void LogAndThrow(Exception e)
        {
            _logger.LogError(e, "Database exception");
            throw new LoggedException(e);
        }
    }
}
