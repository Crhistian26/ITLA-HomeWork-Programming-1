using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Interfaces
{
    public interface ILibrarianService
    {
        Task<IEnumerable<LibrarianDTO>> GetAllAsync();
        Task<LibrarianDTO> GetByIdAsync(int id);
        Task<LibrarianDTO> AddAsync(CreateLibrarianDTO dto);
        Task<LibrarianDTO> UpdateAsync(LibrarianDTO dto);
        Task DeleteAsync(int id);
    }
}
