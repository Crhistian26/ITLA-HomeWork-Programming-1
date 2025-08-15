using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Enum;
using BiblioUniversity.Domain.Interfaces.Repositories;
using BiblioUniversity.Infraestructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Infraestructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public BiblioContext _context { get; set; }
        public UsersRepository(BiblioContext context) { _context = context; }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await
                _context.Users.Select(x=>x)
                .Where(x=> x.Username == username && x.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await
                _context.Users.Select(x => x)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetWithPersonByIdAsync(int id)
        {
            return await
                _context.Users.Select(x => x)
                .Include(x=> x.Person)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllWithPersonAsync()
        {
            return await _context.Users.Include(x=>x.Person).ToListAsync();
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            user = await _context.Users.Select(x => x)
                .Where(x => x.Id == user.Id)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<bool> ConfirmUserExists(string username)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x=> x.Username == username);

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
