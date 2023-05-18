using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Tutor.Server.Domain.Abstractions;
using Tutor.Server.Domain.Entities;
using Tutor.Server.Infrastructure.Database;

namespace Tutor.Server.Infrastructure.Repositories;

internal class ImageRepository : RepositoryBase, IImageRepository
{
    public ImageRepository(TutorDbContext dbContext, ILogger<ImageRepository> logger)
        : base(dbContext, logger)
    {
    }

    public async Task AddAsync(ProfileImage profileImage)
    {
        try
        {
            var current = await _dbContext.ProfileImages.FirstOrDefaultAsync(i => i.UserId == profileImage.UserId);

            if (current is null)
            {
                await _dbContext.ProfileImages.AddAsync(profileImage);
            }
            else
            {
                current.Bytes = profileImage.Bytes;
            }

            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            LogAndThrow(e);
            throw new UnreachableException();
        }
    }

    public void Remove(ProfileImage img)
    {
        _dbContext.Remove(img);
    }
}
