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
    public class StudentService : IStudentService
    {
        private readonly IStudentsRepository _repo;

        public StudentService(IStudentsRepository repo) => _repo = repo;

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(e => new StudentDTO(e));

        public async Task<StudentDTO> GetByIdAsync(int id)
            => new StudentDTO(await _repo.GetByIdAsync(id));

        public async Task<StudentDTO> AddAsync(CreateStudentDTO dto)
        {
            var entity = new Student
            (
                0,
                dto.PersonId,
                dto.EnrollmentId
            );

            var added = await _repo.AddAsync(entity);
            return new StudentDTO(added);
        }

        public async Task<StudentDTO> UpdateAsync(StudentDTO dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            entity.PersonId = dto.PersonId;
            entity.EnrollmentId = dto.EnrollmentId;
            var updated = await _repo.UpdateAsync(entity);

            return new StudentDTO(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(entity);
        }
    }
}
