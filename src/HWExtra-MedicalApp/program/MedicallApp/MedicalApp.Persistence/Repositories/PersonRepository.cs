using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MedicalApp.Persistence.Repositories
{
    public class PersonRepository : IRepository<Person>, IPersonRepository<Person>
    {
        private readonly MedicalContext _context;
        public PersonRepository(MedicalContext context) { _context = context; }

        public Person GetByName(string name)
        {
            Person data = _context.Persons.Where(x => x.Name == name).FirstOrDefault();
            return data;
        }

        public Person GetById(int id)
        {
            Person data = _context.Persons.Where(x=> x.Id == id).FirstOrDefault();
            return data;
        }
        public List<Person> GetAll()
        {
            List<Person> data = _context.Persons.ToList();
            return data;
        }
        public void Add(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }
        public void Update(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }
        public void Delete(Person person)
        {
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
        public void DeleteAll()
        {
            _context.Persons.RemoveRange(_context.Persons);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            _context.Persons.Remove(
                _context.Persons.Where(x=> x.Id == id).FirstOrDefault()
                );
            _context.SaveChanges();
        }
    }
}
