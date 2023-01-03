using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Shared.Exceptions
{
    public class CantDeleteAdvertisementException : ForbiddenException
    {
        public CantDeleteAdvertisementException() : base("You cannot delete this advertisement.")
        {
        }
    }
}
