using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Helpers
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string msg)
            : base(msg)
        {

        }
    }

    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string msg)
            : base(msg)
        {

        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string msg)
            : base(msg)
        {

        }
    }

    public class NotAllowedException : Exception
    {
        public NotAllowedException(string msg)
            : base(msg)
        {

        }
    }

    public class UnprocesableEntity : Exception
    {
        public UnprocesableEntity(string msg)
            : base(msg)
        {

        }
    }
}
