using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using BiblioUniversity.Application.Interfaces;
using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Enum;
using BiblioUniversity.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationsRepository _repo;
        private readonly IStock_BooksRepository _stock;

        public ReservationService(IReservationsRepository repo, IStock_BooksRepository stock)
        {
            _repo = repo;
            _stock = stock;
        }
            

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
                Reservation_status.Pending,
                dto.Request_date,
                dto.Withdrawal_date,
                dto.Return_date
            );

            var added = await _repo.AddAsync(entity);

            var stock = await _stock.GetByBookId(entity.BookId);
            stock.Available -= added.Quantify;
            await _stock.UpdateAsync(stock);
            
            return new ReservationDTO(added);
        }

        public async Task<ReservationDTO> UpdateAsync(ReservationDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            entity.StudentId = dto.StudentId;
            entity.BookId = dto.BookId;
            entity.Quantify = dto.Quantify;
            entity.Status = dto.Status;
            entity.Description = dto.Description;
            entity.Request_date = dto.Request_date;
            entity.Withdrawal_date = dto.Withdrawal_date;
            entity.Return_date = dto.Return_date;

            if(dto.Status == Reservation_status.Rejected)
            {
                var stock = await _stock.GetByBookId(entity.BookId);
                stock.Available += entity.Quantify;
                await _stock.UpdateAsync(stock);
            }

            var updated = await _repo.UpdateAsync(entity);
            return new ReservationDTO(updated);
        }

        public async Task AcceptAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            entity.Status = Reservation_status.Approved;
        }

        public async Task CanceledAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            entity.Status = Reservation_status.Rejected;
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }
    }
}
