using MedicalApp.Domain.Entitys;
using MedicalApp.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public List<Doctor> GetAllWithPersonData()
        {
            List<Doctor> data = _context.Doctors.Include(x => x.Person).ToList();
            return data;
        }

        public List<Doctor> GetAll_WithPersonData_NoHaveUser()
        {
            List<Doctor> data = _context.Doctors.Include(x => x.Person).Where(x=> x.User == null).ToList();
            return data;
        }
        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }
        public void Delete(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
        public void DeleteAll()
        {
            _context.Doctors.RemoveRange(_context.Doctors);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            _context.Doctors.Remove(
                _context.Doctors.Where(x => x.Id == id).FirstOrDefault()
            );
            _context.SaveChanges();
        }
    }
}