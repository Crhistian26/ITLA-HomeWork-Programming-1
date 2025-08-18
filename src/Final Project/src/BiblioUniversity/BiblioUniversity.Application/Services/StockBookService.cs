using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using BiblioUniversity.Application.Interfaces;
using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Services
{
    public class StockBookService : IStockBookService
    {
        private readonly IStock_BooksRepository _repo;

        public StockBookService(IStock_BooksRepository repo) => _repo = repo;

        public async Task<IEnumerable<StockBookDTO>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(e => new StockBookDTO(e));

        public async Task<StockBookDTO> GetByIdAsync(int id)
            => new StockBookDTO(await _repo.GetByIdAsync(id));

        public async Task<StockBookDTO> AddAsync(CreateStockBookDTO dto)
        {
            var entity = new Stock_Book
            (
                0,
                dto.BookId,
                dto.Available,
                dto.Existing
            );

            var added = await _repo.AddAsync(entity);
            return new StockBookDTO(added);
        }

        public async Task<StockBookDTO> UpdateAsync(StockBookDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            entity.BookId = dto.BookId;
            entity.Available = dto.Available;
            entity.Existing = dto.Existing;
            var updated = await _repo.UpdateAsync(entity);

            return new StockBookDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }
    }
}
