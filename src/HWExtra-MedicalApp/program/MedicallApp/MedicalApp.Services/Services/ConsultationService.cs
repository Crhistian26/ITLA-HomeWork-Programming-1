using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence.Repositories;
using System.Collections.Generic;

namespace MedicalApp.Services.Services
{
    public class ConsultationService
    {
        private readonly ConsultationRepository _consultationRepository;

        public ConsultationService(ConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public Consultation GetConsultationById(int id)
        {
            var consultation = _consultationRepository.GetById(id);
            return consultation;
        }

        public List<Consultation> GetAllConsultations()
        {
            var consultations = _consultationRepository.GetAll();
            return consultations;
        }

        public List<Consultation> GetConsultationsPending()
        {
            var consultations = _consultationRepository.GetConsultationsPending();
            return consultations;
        }
        public void AddConsultation(Consultation consultation)
        {
            if (consultation == null)
            {
                throw new ExceptionServices("La consulta a agregar no puede ser nula.");
            }
            _consultationRepository.Add(consultation);
        }

        public void UpdateConsultation(Consultation consultation)
        {
            if (consultation == null)
            {
                throw new ExceptionServices("La consulta a actualizar no puede ser nula.");
            }
            _consultationRepository.Update(consultation);
        }

        public void DeleteConsultation(int id)
        {
            var consultation = _consultationRepository.GetById(id);
            if (consultation == null)
            {
                throw new ExceptionServices($"No se puede eliminar. No existe una consulta con el ID {id}.");
            }
            _consultationRepository.Delete(consultation);
        }
    }
}