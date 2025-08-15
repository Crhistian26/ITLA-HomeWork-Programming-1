using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Exceptions
{
    public class ExceptionService : Exception
    {
        public ExceptionService() { }
        public ExceptionService(string message) : base(message) { }
         
    }
}
