using AutoMapper;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Mapping;

internal class AccountMap : IMap
{
    public void ConfigureMap(Profile profile)
    {
        profile.CreateMap<UpdateUserDto, User>()
            .ForMember(u => u.Tutor.Description, c => c.MapFrom(s => s.Description));

        profile.CreateMap<CreateProfileImageDto, ProfileImage>();
    }
}
