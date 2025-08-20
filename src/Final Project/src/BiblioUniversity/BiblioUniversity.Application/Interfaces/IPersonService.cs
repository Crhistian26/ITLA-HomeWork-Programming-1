using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetAllAsync();
        Task<PersonDTO> GetByIdAsync(int id);
        Task<PersonDTO> AddAsync(CreatePersonDTO dto);
        Task<PersonDTO> UpdateAsync(PersonDTO dto);
        Task DeleteAsync(int id);
        Task<bool> ConfirmIdCard(string idcard);
    }
}
