using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories;
using BiblioUniversity.Infraestructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.Repositories
{
    public class LibrariansRepository : ILibrariansRepository
    {
        private readonly BiblioContext _context;
        public LibrariansRepository(BiblioContext context) { _context = context; }
        public async Task<Librarian> GetByIdAsync(int id)
        {
            return await _context.Librarianes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Librarian>> GetAllAsync()
        {
            return await _context.Librarianes.ToListAsync();
        }
        public async Task<Librarian> AddAsync(Librarian entity)
        {
            _context.Librarianes.AddAsync(entity);
            _context.SaveChanges();
            return await _context.Librarianes.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task<Librarian> UpdateAsync(Librarian entity)
        {
            _context.Librarianes.Update(entity);
            _context.SaveChanges();
            return await _context.Librarianes.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task DeleteAsync(Librarian entity)
        {
            _context.Librarianes.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Librarian> GetByIdWithPersonAsync(int id)
        {
            return await _context.Librarianes.Include(x => x.Person).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Librarian>> GetAllWithPersonAsync()
        {
            return await _context.Librarianes.Include(x => x.Person).ToListAsync();
        }
    }
}
