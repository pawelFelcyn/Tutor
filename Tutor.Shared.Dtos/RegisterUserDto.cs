﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Shared.Dtos
{
    public record RegisterUserDto(string FirstName, string LastName, string Role, string Email, string Password, string ConfirmPassword);
}
