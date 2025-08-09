using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Exceptions
{
    internal class ExceptionEntity : Exception
    {
        public ExceptionEntity() { }

        public ExceptionEntity(string message) : base(message) { }
    }
}
