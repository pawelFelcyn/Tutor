using AutoMapper;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Mapping;

public class ProfileImageMap : IMap
{
    public void ConfigureMap(Profile profile)
    {
        profile.CreateMap<CreateProfileImageDto, ProfileImage>();
        profile.CreateMap<ProfileImage, ProfileImageDto>();
    }
}
