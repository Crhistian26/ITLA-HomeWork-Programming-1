using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using BiblioUniversity.Application.Interfaces;
using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
using BiblioUniversity.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _repo;

        public BookService(IBooksRepository repo) => _repo = repo;

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(e => new BookDTO(e));

        public async Task<BookDTO> GetByIdAsync(int id)
            => new BookDTO(await _repo.GetByIdAsync(id));

        public async Task<IEnumerable<BookDTO>> GetAllWithAllDataAsync()
            => (await _repo.GetAllWithAllDataAsync()).Select(e => new BookDTO(e));

        public async Task<BookDTO> GetByIdWithAllDataAsync(int id)
            => new BookDTO(await _repo.GetByIdWithAllDataAsync(id));

        public async Task<BookDTO> AddAsync(CreateBookDTO dto)
        {
            var entity = new Book
            (
                dto.Title,
                dto.Edition,
                dto.Pages,
                dto.Url_image,
                dto.Url_digital,
                dto.Authors,
                dto.Genres,
                
                dto.Languages
                
            );

            var added = await _repo.AddAsync(entity);
            return new BookDTO(added);
        }

        public async Task<BookDTO> UpdateAsync(BookDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            entity.Title = dto.Title;
            entity.Edition = dto.Edition;
            entity.Pages = dto.Pages;
            entity.Url_image = dto.Url_image;
            entity.Url_digital = dto.Url_digital;

            var updated = await _repo.UpdateAsync(entity);
            return new BookDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Language>> GetLanguages()
        {
            return await _repo.GetLanguages();
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            return await _repo.GetGenres();
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _repo.GetAuthors();
        }
    }
}
