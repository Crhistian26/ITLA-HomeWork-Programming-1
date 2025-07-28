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

        public List<Consultation> GetConsultationsPending(Doctor doct)
        {
            List<Consultation> data;
           
            data = _context.Consultations.Where(x => x.Pending == true && x.Doctor == doct).ToList();

            return data;
        }
        public void Add(Consultation consultation)
        {
            _context.Consultations.Add(consultation);
            _context.SaveChanges();
        }
        public void Update(Consultation consultation)
        {
            _context.Consultations.Update(consultation);
            _context.SaveChanges();
        }
        public void Delete(Consultation consultation)
        {
            _context.Consultations.Remove(consultation);
            _context.SaveChanges();
        }
        public void DeleteAll()
        {
            _context.Consultations.RemoveRange(_context.Consultations);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            _context.Consultations.Remove(
                _context.Consultations.Where(x => x.Id == id).FirstOrDefault()
            );
            _context.SaveChanges();
        }
    }
}