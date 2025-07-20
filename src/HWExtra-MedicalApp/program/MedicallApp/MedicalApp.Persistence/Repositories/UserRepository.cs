using MedicalApp.Domain.Entitys;
using MedicalApp.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MedicalApp.Persistence.Repositories
{
    internal class UserRepository : IRepository<User>
    {
        private readonly MedicalContext _context;
        public UserRepository(MedicalContext context) { _context = context; }

        public User GetById(int id)
        {
            User data = _context.Users.Where(x => x.Id == id).FirstOrDefault();
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
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }
        public void DeleteAll()
        {
            _context.Users.RemoveRange(_context.Users);
        }
        public void DeleteById(int id)
        {
            _context.Users.Remove(
                _context.Users.Where(x => x.Id == id).FirstOrDefault()
            );
        }
    }
}
