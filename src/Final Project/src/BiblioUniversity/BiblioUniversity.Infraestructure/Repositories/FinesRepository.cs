using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories;
using BiblioUniversity.Infraestructure.BaseDatosContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.Repositories
{
    public class FinesRepository : IFinesRepository
    {
        private readonly BiblioContext _context;
        public FinesRepository(BiblioContext context) { _context = context; }
        public async Task<Fine> GetByIdAsync(int id)
        {
            return await _context.Fines.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Fine>> GetAllAsync()
        {
            return await _context.Fines
                .Include(f=>f.Reservation)
                .ThenInclude(r=>r.Student)
                .ThenInclude(s=>s.Person)
                .Include(f => f.Reservation)
                .ThenInclude(r => r.Student)
                .ThenInclude(s => s.Enrollment)
                .ToListAsync();
        }
        public async Task<Fine> AddAsync(Fine entity)
        {
            _context.Fines.AddAsync(entity);
            _context.SaveChanges();
            return await _context.Fines.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task<Fine> UpdateAsync(Fine entity)
        {
            _context.Fines.Update(entity);
            _context.SaveChanges();
            return await _context.Fines.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task DeleteAsync(Fine entity)
        {
            _context.Fines.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Fine> GetByIdWithReservationAsync(int id)
        {
            return await _context.Fines
                .Include(x=> x.Reservation)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Fine>> GetAllWithReservationAsync()
        {
            return await _context.Fines
                .Include(x => x.Reservation)
                .ToListAsync();
        }
    }
}
