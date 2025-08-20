using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDTO>> GetAllAsync();
        Task<ReservationDTO> GetByIdAsync(int id);
        Task<IEnumerable<ReservationDTO>> GetAllWithStudentBookAsync();
        Task<ReservationDTO> GetByIdWithStudentBookAsync(int id);
        Task<ReservationDTO> AddAsync(CreateReservationDTO dto);
        Task<ReservationDTO> UpdateAsync(ReservationDTO dto);

        Task AcceptAsync(int id);
        Task CanceledAsync(int id);
        Task DeleteAsync(int id);
    }
}
