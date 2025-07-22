using MedicalApp.Domain.Entitys;
using MedicalApp.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MedicalApp.Persistence.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly MedicalContext _context;
        public UserRepository(MedicalContext context) { _context = context; }

        public User Login(string username, string password)
        {
            User data = _context.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            return data;
        }
        public User GetById(int id)
        {
            User data = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
        public User GetById_WithDoctorData(int id)
        {
            User data = _context.Users.Include(x => x.Doctor)
                .ThenInclude(d => d.Person)
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return data;
        }
        public List<User> GetAll()
        {
            List<User> data = _context.Users.ToList();
            return data;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void DeleteAll()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            _context.Users.Remove(
                _context.Users.Where(x => x.Id == id).FirstOrDefault()
            );
            _context.SaveChanges();
        }
    }
}
