using AutoMapper;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Mapping;

public class SubjectMap : IMap
{
    public void ConfigureMap(Profile profile)
    {
        profile.CreateMap<SchoolSubject, SubjectDto>();
    }
}
