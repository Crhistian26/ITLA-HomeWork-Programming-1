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
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrariansRepository _repo;

        public LibrarianService(ILibrariansRepository repo) => _repo = repo;

        public async Task<IEnumerable<LibrarianDTO>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(e => new LibrarianDTO(e));

        public async Task<LibrarianDTO> GetByIdAsync(int id)
            => new LibrarianDTO(await _repo.GetByIdAsync(id));

        public async Task<LibrarianDTO> AddAsync(CreateLibrarianDTO dto)
        {
            var entity = new Librarian
            (
                0,
                dto.PersonId,
                dto.License
            );

            var added = await _repo.AddAsync(entity);
            return new LibrarianDTO(added);
        }

        public async Task<LibrarianDTO> UpdateAsync(LibrarianDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            entity.PersonId = dto.PersonId;
            entity.License = dto.License;

            var updated = await _repo.UpdateAsync(entity);
            return new LibrarianDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }
    }
}
