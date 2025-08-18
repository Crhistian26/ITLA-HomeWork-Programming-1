using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Interfaces
{
    public interface IFineService
    {
        Task<IEnumerable<FineDTO>> GetAllAsync();
        Task<FineDTO> GetByIdAsync(int id);
        Task<FineDTO> AddAsync(CreateFineDTO dto);
        Task<FineDTO> UpdateAsync(FineDTO dto);
        Task DeleteAsync(int id);
    }
}
