using Microsoft.EntityFrameworkCore;
using Tutor.Server.Domain.Entities;
using Tutor.Server.Infrastructure.Database;

namespace Tutor.Server.API;

public class DataSeeder
{
    private readonly TutorDbContext _dbContext;

    public DataSeeder(TutorDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task SeedData()
	{
		ApplyPendingMigrations();
		await SeedSchoolSubjects();
        await _dbContext.SaveChangesAsync();
	}

    private void ApplyPendingMigrations()
    {
		if (_dbContext.Database.IsRelational() && _dbContext.Database.GetPendingMigrations().Any())
		{
			_dbContext.Database.Migrate();
		}
    }

    private async Task SeedSchoolSubjects()
    {
		if (_dbContext.SchoolSubjects.Any())
		{
			return;
		}

		await _dbContext.SchoolSubjects.AddRangeAsync(new List<SchoolSubject>()
		{
			new()
			{
				Name = "Polish"
            },
            new()
            {
                Name = "English"
            },
            new()
            {
                Name = "German"
            },
            new()
            {
                Name = "French"
            },
            new()
            {
                Name = "Italian"
            },
            new()
            {
                Name = "Spanish"
            },
            new()
            {
                Name = "Math"
            },
            new()
            {
                Name = "Physics"
            },
            new()
            {
                Name = "Art"
            },
            new()
            {
                Name = "ComputerScience"
            },
            new()
            {
                Name = "Biology"
            },
            new()
            {
                Name = "Chemistry"
            },
            new()
            {
                Name = "History"
            },
            new()
            {
                Name = "Geography"
            }
        });
    }
}
