using MedicalApp.Domain.Entitys;
using MedicalApp.Persistence.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MedicalApp.Persistence.Repositories
{
    public class ConsultationRepository : IRepository<Consultation>
    {
        private readonly MedicalContext _context;
        public ConsultationRepository(MedicalContext context) { _context = context; }

        public Consultation GetById(int id)
        {
            Consultation data = _context.Consultations.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
        public List<Consultation> GetAll()
        {
            List<Consultation> data = _context.Consultations.ToList();
            return data;
        }

        public List<Consultation> GetConsultationsPending()
        {
            List<Consultation> data;
            if (_context._user.Rol == Domain.Enums.Rol.Doctor)
            {
                data = _context.Consultations.Where(x => x.Pending == true && x.Doctor.User == _context._user).ToList();
            }
            else 
            {
                data = _context.Consultations.Where(x => x.Pending == true).ToList();
            }
            return data;
        }
        public void Add(Consultation consultation)
        {
            _context.Consultations.Add(consultation);
        }
        public void Update(Consultation consultation)
        {
            _context.Consultations.Update(consultation);
        }
        public void Delete(Consultation consultation)
        {
            _context.Consultations.Remove(consultation);
        }
        public void DeleteAll()
        {
            _context.Consultations.RemoveRange(_context.Consultations);
        }
        public void DeleteById(int id)
        {
            _context.Consultations.Remove(
                _context.Consultations.Where(x => x.Id == id).FirstOrDefault()
            );
        }
    }
}