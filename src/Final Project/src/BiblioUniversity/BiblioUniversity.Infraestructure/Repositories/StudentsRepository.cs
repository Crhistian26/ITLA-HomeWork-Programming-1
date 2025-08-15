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
    public class StudentsRepository : IStudentsRepository
    {
        private readonly BiblioContext _context;
        public StudentsRepository(BiblioContext context) { _context = context; }
        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> AddAsync(Student entity)
        {
            _context.Students.AddAsync(entity);
            _context.SaveChanges();
            return await _context.Students.FirstOrDefaultAsync(x=>x.Id == entity.Id);
        }
        public async Task<Student> UpdateAsync(Student entity)
        {
            _context.Students.Update(entity);
            _context.SaveChanges();
            return await _context.Students.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task DeleteAsync(Student entity)
        {
            _context.Students.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Student> GetByIdWithPersonAsync(int id)
        {
            return await _context.Students.Include(x=> x.Person).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Student>> GetAllWithPersonAsync()
        {
            return await _context.Students.Include(x=>x.Person).ToListAsync();
        }
    }
}
