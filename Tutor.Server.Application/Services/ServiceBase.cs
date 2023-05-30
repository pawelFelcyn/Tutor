using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Services;

public abstract class ServiceBase
{
    protected IQueryable<T> ApplyPages<T>(IQueryable<T> query, TutorSieveModel sieveModel)
    {
        var skip = (sieveModel.PageNumber - 1) * sieveModel.PageSize;
        return query.Skip(skip).Take(sieveModel.PageSize);
    }
}
