using MedicalApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Visual.Views.Principal_Views
{
    public abstract class PrincipalViewBase
    {
        protected MedicalContext _medicalContext;
        public PrincipalViewBase(MedicalContext medicalContext) 
        {
            _medicalContext = medicalContext;
        }
    }
}
