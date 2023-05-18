using AutoMapper;
using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Server.Domain.Entities;
using Tutor.Shared.Dtos;

namespace Tutor.Server.Application.Mapping;

public class AuthenticationMap : IMap
{
    public void ConfigureMap(Profile profile)
    {
        profile.CreateMap<RegisterUserDto, User>()
               .ForMember(u => u.Tutor, c => c.MapFrom(s => CreateTutor(s)));
        profile.CreateMap<User, UserDetailsDto>()
            .ForMember(d => d.Description, s => s.MapFrom(c => GetTutorDescription(c)))
            .ForMember(d => d.ProfileImage, s => s.MapFrom(c => GetProfileImage(c)));
    }

    private string GetTutorDescription(User user) => user.Tutor?.Description;
    private byte[] GetProfileImage(User user) => user.PofileImage?.Bytes;

    private TutorEntity CreateTutor(RegisterUserDto dto)
    {
        return string.IsNullOrEmpty(dto.TutorDescription)
            ? null
            : new TutorEntity
            {
                Description = dto.TutorDescription
            };
    }
}
