using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Exceptions
{
    internal class ExceptionDomain : Exception
    {
        public ExceptionDomain() { }

        public ExceptionDomain(string message) : base(message) { }
    }
}
