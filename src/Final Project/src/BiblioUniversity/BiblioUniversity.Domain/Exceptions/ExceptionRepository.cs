using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Exceptions
{
    public class ExceptionRepository : Exception
    {
        public ExceptionRepository() { }
        public ExceptionRepository(string message) : base(message) { }
    }
}
