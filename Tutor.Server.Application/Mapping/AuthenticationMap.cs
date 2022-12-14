using AutoMapper;
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
        profile.CreateMap<RegisterUserDto, User>();
    }
}
