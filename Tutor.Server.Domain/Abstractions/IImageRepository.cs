using Tutor.Server.Domain.Entities;

namespace Tutor.Server.Domain.Abstractions;

public interface IImageRepository
{
    Task AddAsync(ProfileImage profileImage);
}
