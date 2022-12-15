using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Shared.Exceptions
{
    public class LoggedException : Exception
    {
        public LoggedException(Exception inner) : base("Exception has been thrown and already logged", inner)
        {

        }
    }
}
