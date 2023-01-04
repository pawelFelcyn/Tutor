using Tutor.Server.Infrastructure.Database;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Server.Infrastructure.Helpers;

internal class SubjectValidationHelper : ISubjectValidationHelper
{
    private readonly TutorDbContext _dbContext;

    public SubjectValidationHelper(TutorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Exists(Guid id)
    {
        return _dbContext.SchoolSubjects.Any(s => s.Id == id);
    }
}
