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
    public class FineService : IFineService
    {
        private readonly IFinesRepository _repo;

        public FineService(IFinesRepository repo) => _repo = repo;

        public async Task<IEnumerable<FineDTO>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(e => new FineDTO(e));

        public async Task<FineDTO> GetByIdAsync(int id)
            => new FineDTO(await _repo.GetByIdAsync(id));

        public async Task<FineDTO> AddAsync(CreateFineDTO dto)
        {
            var entity = new Fine
            (
                0,
                dto.Description,
                dto.ReservationId,
                dto.Amaunt,
                dto.Fine_Status
            );

            var added = await _repo.AddAsync(entity);
            return new FineDTO(added);
        }

        public async Task<FineDTO> UpdateAsync(FineDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            entity.Description = dto.Description;
            entity.Amaunt = dto.Amaunt;
            entity.Fine_Status = dto.Fine_Status;
            entity.ReservationId = dto.ReservationId;

            var updated = await _repo.UpdateAsync(entity);
            return new FineDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }
    }
}
