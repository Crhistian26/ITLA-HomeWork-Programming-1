using ContactsApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Infraestructure.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        public T GetByName(string name);
        public List<T> GetAll();
        public T GetById(int id);
        public bool Add(T entity);
        public bool Update(T entity);
        public bool Delete(int id);
          
    }
}
