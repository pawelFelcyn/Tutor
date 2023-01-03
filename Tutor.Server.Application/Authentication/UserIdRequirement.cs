using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Server.Application.Authentication
{
    public class UserIdRequirement : Requirement<UserIdRequirement>
    {
        public Guid RequiredId { get; }

        public UserIdRequirement(Guid requiredId)
        {
            RequiredId = requiredId;
        }
    }
}
