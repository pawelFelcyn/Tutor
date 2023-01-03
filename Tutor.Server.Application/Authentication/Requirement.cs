using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Server.Application.Authentication
{
    public abstract class Requirement : IAuthorizationRequirement
    {
        public abstract Type GetHandlerType();
    }
    
    public abstract class Requirement<T> : Requirement where T : IAuthorizationRequirement
    {
        public override Type GetHandlerType() => typeof(AuthorizationHandler<T>);
    }
}
