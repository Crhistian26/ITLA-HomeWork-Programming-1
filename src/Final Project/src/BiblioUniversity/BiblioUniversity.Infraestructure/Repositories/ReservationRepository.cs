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
    public class ReservationRepository : IReservationsRepository
    {
        private readonly BiblioContext _context;
        public ReservationRepository(BiblioContext context) { _context = context; }
        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }
        public async Task<Reservation> AddAsync(Reservation entity)
        {
            _context.Reservations.AddAsync(entity);
            _context.SaveChanges();
            return await _context.Reservations.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task<Reservation> UpdateAsync(Reservation entity)
        {
            _context.Reservations.Update(entity);
            _context.SaveChanges();
            return await _context.Reservations.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task DeleteAsync(Reservation entity)
        {
            _context.Reservations.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Reservation> GetByIdWithStudentBookAsync(int id)
        {
            return await _context.Reservations
                .Include(x=> x.Book)
                .Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Reservation>> GetAllWithStudentBook()
        {
            return await _context.Reservations
                .Include(x => x.Book)
                .Include(x => x.Student)
                .ToListAsync();
        }

    }
}
