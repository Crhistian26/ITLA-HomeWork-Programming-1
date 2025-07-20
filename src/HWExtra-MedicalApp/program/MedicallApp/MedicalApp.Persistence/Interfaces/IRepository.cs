using MedicalApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Persistence.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        public T GetById(int id);
        public List<T> GetAll();
        public void Add(T add);
        public void Update(T update);
        public void Delete(T delte);
        public void DeleteById(int id);
        public void DeleteAll();
    }
}
 