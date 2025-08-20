using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
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
    public class BooksRepositoy : IBooksRepository
    {
        private readonly BiblioContext _context;
        
        public BooksRepositoy(BiblioContext context) { _context = context; }
        public async Task<Book> GetByIdAsync(int id) 
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> AddAsync(Book entity)
        {
            _context.Books.AddAsync(entity);
            _context.SaveChanges();
            return entity; 
        }
        public async Task<Book> UpdateAsync(Book entity)
        {
            _context.Books.Update(entity);
            _context.SaveChanges();
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }
        public async Task DeleteAsync(Book entity)
        {
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Book>> GetAllWithAllDataAsync()
        {
            return await _context.Books
                .Include(x => x.Authors)
                .Include(x => x.Languages)
                .Include(x => x.Genres)
                .ToListAsync();
        }
        public async Task<Book> GetByIdWithAllDataAsync(int id)
        {
            return await _context.Books
                .Include(x => x.Authors)
                .Include(x => x.Languages)
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Language>> GetLanguages()
        {
            return _context.Languages.ToList();
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return _context.Authors.ToList();
        }
    }
}
