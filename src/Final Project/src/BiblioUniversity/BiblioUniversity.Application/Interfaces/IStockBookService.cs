using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Interfaces
{
    public interface IStockBookService
    {
        Task<IEnumerable<StockBookDTO>> GetAllAsync();
        Task<StockBookDTO> GetByIdAsync(int id);
        Task<StockBookDTO> AddAsync(CreateStockBookDTO dto);
        Task<StockBookDTO> UpdateAsync(StockBookDTO dto);
        Task DeleteAsync(int id);
    }
}
