using Tutor.Server.Infrastructure.Database;
using Tutor.Shared.Helpers.Abstractions;

namespace Tutor.Server.Infrastructure.Helpers;

public class EmailValidationHelper : IEmailValidationHelper
{
    private readonly TutorDbContext _dbContext;

    public EmailValidationHelper(TutorDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool IsEmailTaken(string email)
    {
        return _dbContext.Users.Any(u => u.Email == email);
    }
}
