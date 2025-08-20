using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using BiblioUniversity.Domain.Entities.DataOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllAsync();
        Task<BookDTO> GetByIdAsync(int id);
        Task<IEnumerable<BookDTO>> GetAllWithAllDataAsync();
        Task<BookDTO> GetByIdWithAllDataAsync(int id);
        Task<BookDTO> AddAsync(CreateBookDTO dto);
        Task<BookDTO> UpdateAsync(BookDTO dto);
        Task DeleteAsync(int id);

        Task<IEnumerable<Language>> GetLanguages();

        Task<IEnumerable<Genre>> GetGenres();

        Task<IEnumerable<Author>> GetAuthors();
    }
}
