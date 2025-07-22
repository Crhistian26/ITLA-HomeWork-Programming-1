using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence.Repositories;
using System.Collections.Generic;

namespace MedicalApp.Services.Services
{
    public class DoctorService
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor GetDoctorById(int id)
        {
            var doctor = _doctorRepository.GetById(id);
            if (doctor == null)
            {
                throw new ExceptionServices($"No se encontró un doctor con el ID {id}.");
            }
            return doctor;
        }

        public Doctor GetDoctorByName(string name)
        {
            var doctor = _doctorRepository.GetByName(name);
            if (doctor == null)
            {
                throw new ExceptionServices($"No se encontró un doctor con el nombre '{name}'.");
            }
            return doctor;
        }

        public List<Doctor> GetAllDoctors()
        {
            var doctors = _doctorRepository.GetAll();
            if (doctors == null || doctors.Count == 0)
            {
                throw new ExceptionServices("No hay doctores registrados.");
            }
            return doctors;
        }

        public List<Doctor> GetAllDoctors_WithPersonData()
        {
            var doctors = _doctorRepository.GetAllWithPersonData();
            if (doctors == null || doctors.Count == 0)
            {
                throw new ExceptionServices("No hay doctores registrados.");
            }
            return doctors;
        }

        public List<Doctor> GetAllDoctor_WithPersonData_NoHaveUser()
        {
            var doctors = _doctorRepository.GetAll_WithPersonData_NoHaveUser();
            if (doctors == null || doctors.Count == 0)
            {
                throw new ExceptionServices("Lo sentimos, todos los doctores ya tienen un usuario asignado.");
            }
            return doctors;
        }
        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ExceptionServices("El doctor a agregar no puede ser nulo.");
            }
            _doctorRepository.Add(doctor);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ExceptionServices("El doctor a actualizar no puede ser nulo.");
            }
            _doctorRepository.Update(doctor);
        }

        public void DeleteDoctor(int id)
        {
            var doctor = _doctorRepository.GetById(id);
            if (doctor == null)
            {
                throw new ExceptionServices($"No se puede eliminar. No existe un doctor con el ID {id}.");
            }
            _doctorRepository.Delete(doctor);
        }
    }
}