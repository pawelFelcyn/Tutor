namespace Tutor.Server.Domain.Abstractions;

public interface ICollectionMaterializingRepository<T> : IRepository where T : class
{
    Task<IEnumerable<T>> MaterializeAsync(IQueryable<T> query); 
}
