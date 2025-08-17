using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using BiblioUniversity.Infraestructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.Repositories
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly BiblioContext _context;
        public PersonsRepository(BiblioContext context) { _context = context; }
        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }
        public async Task<Person> AddAsync(Person entity)
        {
            _context.Persons.AddAsync(entity);
            _context.SaveChanges();
            return await _context.Persons.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task<Person> UpdateAsync(Person entity)
        {
            _context.Persons.Update(entity);
            _context.SaveChanges();
            return await _context.Persons.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task DeleteAsync(Person entity)
        {
            _context.Persons.Remove(entity);
            _context.SaveChanges();
        }
    }
}
