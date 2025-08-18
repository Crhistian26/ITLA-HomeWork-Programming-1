using BiblioUniversity.Application.DTOs.CreateDTOs;
using BiblioUniversity.Application.DTOs.EntitiesDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserDTO> AddAsync(CreateUserDTO dto);
        Task<UserDTO> UpdateAsync(UserDTO dto);
        Task DeleteAsync(int id);

        Task<UserDTO> LoginAsync(string username, string password);
        Task<bool> ConfirmUserExistsAsync(string username);
    }
}
