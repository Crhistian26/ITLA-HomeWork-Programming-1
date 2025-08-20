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
    public class StockBooksRepository : IStock_BooksRepository
    {
        public BiblioContext _context;
        public StockBooksRepository(BiblioContext context) { _context = context; }

        public async Task<Stock_Book> GetByIdAsync(int id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Stock_Book>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock_Book> AddAsync(Stock_Book entity)
        {
            _context.Stocks.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<Stock_Book> UpdateAsync(Stock_Book entity)
        {
            _context.Stocks.Update(entity);
            _context.SaveChanges();
            return await _context.Stocks.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }

        public async Task DeleteAsync(Stock_Book entity)
        {
            _context.Stocks.Remove(entity);
            _context.SaveChanges();
        }
        public async Task<Stock_Book> GetByIdWithAllBookDataAsync(int id)
        {
            return await _context.Stocks
                .Include(x => x.Book)
                .ThenInclude(b => b.Languages)
                .Include(x => x.Book)
                .ThenInclude(b => b.Genres)
                .Include(x => x.Book)
                .ThenInclude(b => b.Authors)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Stock_Book>> GetAllWithAllDataAsync()
        {
            return await _context.Stocks
                .Include(x => x.Book)
                .ThenInclude(b => b.Languages)
                .Include(x => x.Book)
                .ThenInclude(b => b.Genres)
                .Include(x => x.Book)
                .ThenInclude(b => b.Authors)
                .ToListAsync();
        }

        public async Task<Stock_Book> GetByBookId(int id)
        {
            return _context.Stocks.Select(x => x)
                .Include(x => x.Book)
                .Where(x => x.BookId == id)
                .FirstOrDefault();
        }

    }
}
