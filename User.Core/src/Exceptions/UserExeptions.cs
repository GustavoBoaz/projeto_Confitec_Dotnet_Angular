using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Core.src.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("Email inválido")
        {
        }
    }

    public class InvalidDateException : Exception
    {
        public InvalidDateException() : base("Data inválida")
        {
        }
    }

    public class InvalidScholarityException : Exception
    {
        public InvalidScholarityException() : base("Escolaridade inválida")
        {
        }
    }
}