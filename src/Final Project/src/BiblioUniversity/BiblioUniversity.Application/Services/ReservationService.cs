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
    public class ReservationService : IReservationService
    {
        private readonly IReservationsRepository _repo;

        public ReservationService(IReservationsRepository repo) => _repo = repo;

        public async Task<IEnumerable<ReservationDTO>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(e => new ReservationDTO(e));

        public async Task<ReservationDTO> GetByIdAsync(int id)
            => new ReservationDTO(await _repo.GetByIdAsync(id));

        public async Task<IEnumerable<ReservationDTO>> GetAllWithStudentBookAsync()
            => (await _repo.GetAllWithStudentBook()).Select(e => new ReservationDTO(e));

        public async Task<ReservationDTO> GetByIdWithStudentBookAsync(int id)
            => new ReservationDTO(await _repo.GetByIdWithStudentBookAsync(id));

        public async Task<ReservationDTO> AddAsync(CreateReservationDTO dto)
        {
            var entity = new Reservation
            (
                0,
                dto.StudentId,
                dto.BookId,
                dto.Quantify,
                dto.Description,
                dto.Request_date,
                dto.Withdrawal_date,
                dto.Return_date
            );

            var added = await _repo.AddAsync(entity);
            return new ReservationDTO(added);
        }

        public async Task<ReservationDTO> UpdateAsync(ReservationDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            entity.StudentId = dto.StudentId;
            entity.BookId = dto.BookId;
            entity.Quantify = dto.Quantify;
            entity.Description = dto.Description;
            entity.Request_date = dto.Request_date;
            entity.Withdrawal_date = dto.Withdrawal_date;
            entity.Return_date = dto.Return_date;

            var updated = await _repo.UpdateAsync(entity);
            return new ReservationDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }
    }
}
