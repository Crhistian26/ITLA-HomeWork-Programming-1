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
    public class UserService : IUserService
    {
        private readonly IUsersRepository _repo;

        public UserService(IUsersRepository repo) => _repo = repo;

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(e => new UserDTO(e));

        public async Task<UserDTO> GetByIdAsync(int id)
            => new UserDTO(await _repo.GetByIdAsync(id));

        public async Task<UserDTO> AddAsync(CreateUserDTO dto)
        {
            var entity = new User
            (
                0,
                dto.Username,
                dto.Password,
                dto.Rol,
                dto.PersonId
            );

            var added = await _repo.AddAsync(entity);
            return new UserDTO(added);
        }

        public async Task<UserDTO> UpdateAsync(UserDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            entity.Username = dto.Username;
            entity.Password = dto.Password;
            entity.Rol = dto.Rol;
            entity.PersonId = dto.PersonId;
            var updated = await _repo.UpdateAsync(entity);

            return new UserDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }

        public async Task<UserDTO> LoginAsync(string username, string password)
            => new UserDTO(await _repo.LoginAsync(username, password));

        public async Task<bool> ConfirmUserExistsAsync(string username)
            => _repo.ConfirmUserExists(username);
    }
}
