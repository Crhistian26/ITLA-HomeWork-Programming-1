using MedicalApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Persistence.Interfaces
{
    public interface IPersonRepository<T> where T : class, IEntity
    {
        public T GetByName(string name);
    }
}
