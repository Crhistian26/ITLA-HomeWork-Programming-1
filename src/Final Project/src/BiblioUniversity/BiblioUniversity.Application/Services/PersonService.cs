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
    public class PersonService : IPersonService
    {
        private readonly IPersonsRepository _repo;

        public PersonService(IPersonsRepository repo) => _repo = repo;

        public async Task<IEnumerable<PersonDTO>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(e => new PersonDTO(e));

        public async Task<PersonDTO> GetByIdAsync(int id)
            => new PersonDTO(await _repo.GetByIdAsync(id));

        public async Task<PersonDTO> AddAsync(CreatePersonDTO dto)
        {
            var entity = new Person
            (   
                dto.Name,
                dto.Lastname,
                dto.Telephone,
                dto.Id_Card,
                dto.Address
            );
            if (await _repo.ConfirmIdCard(dto.Id_Card))
            {
                throw new Exception("Ya existe una persona con esta cédula.");
            }

            var added = await _repo.AddAsync(entity);
            return new PersonDTO(added);
        }

        public async Task<PersonDTO> UpdateAsync(PersonDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            entity.Name = dto.Name;
            entity.Lastname = dto.Lastname;
            entity.Telephone = dto.Telephone;
            entity.Id_Card = dto.Id_Card;
            entity.Address = dto.Address;

            var updated = await _repo.UpdateAsync(entity);
            return new PersonDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }

        public async Task<bool> ConfirmIdCard(string idcard)
        {
            return await _repo.ConfirmIdCard(idcard);
        }
    }
}
