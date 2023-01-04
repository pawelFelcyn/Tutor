using Microsoft.Extensions.Logging;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Server.Infrastructure.Database;

namespace Tutor.Server.Infrastructure.Repositories;

internal class SubjectRepository : CollectionMaterializingRepository<SchoolSubject>, ISubjectRepository
{
    public SubjectRepository(TutorDbContext dbContext, ILogger<RepositoryBase> logger) : base(dbContext, logger)
    {
    }

    public IQueryable<SchoolSubject> GetAll()
    {
        return _dbContext.SchoolSubjects;
    }
}
