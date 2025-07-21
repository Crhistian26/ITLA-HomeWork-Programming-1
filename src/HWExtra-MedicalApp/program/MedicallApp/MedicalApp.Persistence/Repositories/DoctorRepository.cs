using MedicalApp.Domain.Entitys;
using MedicalApp.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MedicalApp.Persistence.Repositories
{
    public class DoctorRepository : IRepository<Doctor>, IPersonRepository<Doctor>
    {
        private readonly MedicalContext _context;
        public DoctorRepository(MedicalContext context) { _context = context; }

        public Doctor GetByName(string name)
        {
            Doctor data = _context.Doctors.Where(x => x.Person.Name == name).FirstOrDefault();
            return data;
        }

        public Doctor GetById(int id)
        {
            Doctor data = _context.Doctors.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
        public List<Doctor> GetAll()
        {
            List<Doctor> data = _context.Doctors.ToList();
            return data;
        }
        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
        }
        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }
        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }
        public void DeleteAll()
        {
            _context.Doctors.RemoveRange(_context.Doctors);
        }
        public void DeleteById(int id)
        {
            _context.Doctors.Remove(
                _context.Doctors.Where(x => x.Id == id).FirstOrDefault()
            );
        }
    }
}