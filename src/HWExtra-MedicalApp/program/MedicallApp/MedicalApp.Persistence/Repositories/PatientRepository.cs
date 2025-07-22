using MedicalApp.Domain.Entitys;
using MedicalApp.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MedicalApp.Persistence.Repositories
{
    public class PatientRepository : IRepository<Patient>, IPersonRepository<Patient>
    {
        private readonly MedicalContext _context;
        public PatientRepository(MedicalContext context) { _context = context; }

        public Patient GetByName(string name)
        {
            Patient data = _context.Patients.Where(x => x.Person.Name == name).FirstOrDefault();
            return data;
        }

        public Patient GetById(int id)
        {
            Patient data = _context.Patients.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
        public List<Patient> GetAll()
        {
            List<Patient> data = _context.Patients.ToList();
            return data;
        }
        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }
        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }
        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
        public void DeleteAll()
        {
            _context.Patients.RemoveRange(_context.Patients);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            _context.Patients.Remove(
                _context.Patients.Where(x => x.Id == id).FirstOrDefault()
            );
            _context.SaveChanges();
        }
    }
}