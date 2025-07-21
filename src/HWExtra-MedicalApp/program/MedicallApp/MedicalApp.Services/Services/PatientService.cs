using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence.Repositories;
using System.Collections.Generic;

namespace MedicalApp.Services.Services
{
    public class PatientService
    {
        private readonly PatientRepository _patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Patient GetPatientById(int id)
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                throw new ExceptionServices($"No se encontró un paciente con el ID {id}.");
            }
            return patient;
        }

        public Patient GetPatientByName(string name)
        {
            var patient = _patientRepository.GetByName(name);
            if (patient == null)
            {
                throw new ExceptionServices($"No se encontró un paciente con el nombre '{name}'.");
            }
            return patient;
        }

        public List<Patient> GetAllPatients()
        {
            var patients = _patientRepository.GetAll();
            if (patients == null || patients.Count == 0)
            {
                throw new ExceptionServices("No hay pacientes registrados.");
            }
            return patients;
        }

        public void AddPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ExceptionServices("El paciente a agregar no puede ser nulo.");
            }
            _patientRepository.Add(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ExceptionServices("El paciente a actualizar no puede ser nulo.");
            }
            _patientRepository.Update(patient);
        }

        public void DeletePatient(int id)
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                throw new ExceptionServices($"No se puede eliminar. No existe un paciente con el ID {id}.");
            }
            _patientRepository.Delete(patient);
        }
    }
}