using AutoMapper;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Mapping;

internal class AdverticementMap : IMap
{
    public void ConfigureMap(Profile profile)
    {
        profile.CreateMap<CreateAdvertisementDto, Advertisement>();
        profile.CreateMap<Advertisement, AdvertisementDetailsDto>()
               .ForMember(a => a.Subject, d => d.MapFrom(s => s.Subject.Name));
        profile.CreateMap<Advertisement, AdvertisementDto>();
        profile.CreateMap<UpdateAdvertisementDto, Advertisement>();
    }
}
