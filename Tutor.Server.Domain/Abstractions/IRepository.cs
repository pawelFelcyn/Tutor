namespace Tutor.Server.Domain.Abstractions;

public interface IRepository
{
    Task SaveChangesAsync();
}
