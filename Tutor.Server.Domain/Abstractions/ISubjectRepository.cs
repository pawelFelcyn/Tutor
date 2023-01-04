using Tutor.Server.Domain.Entities;

namespace Tutor.Server.Domain.Abstractions;

public interface ISubjectRepository : ICollectionMaterializingRepository<SchoolSubject>
{
    IQueryable<SchoolSubject> GetAll();
}
