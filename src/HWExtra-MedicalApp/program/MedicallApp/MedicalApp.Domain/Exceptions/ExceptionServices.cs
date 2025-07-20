using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Exceptions
{
    public class ExceptionServices : Exception
    {
        public ExceptionServices(string msg) : base(msg)
        { }
    }
}
