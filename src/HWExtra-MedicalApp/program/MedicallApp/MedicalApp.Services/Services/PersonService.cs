using MedicalApp.Domain.Entitys;
using MedicalApp.Domain.Exceptions;
using MedicalApp.Persistence.Repositories;
using System.Collections.Generic;

namespace MedicalApp.Services.Services
{
    public class PersonService
    {
        private readonly PersonRepository _personRepository;

        public PersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person GetPersonById(int id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                throw new ExceptionServices($"No se encontró una persona con el ID {id}.");
            }
            return person;
        }

        public Person GetPersonByName(string name)
        {
            var person = _personRepository.GetByName(name);
            if (person == null)
            {
                throw new ExceptionServices($"No se encontró una persona con el nombre '{name}'.");
            }
            return person;
        }

        public List<Person> GetAllPersons()
        {
            var persons = _personRepository.GetAll();
            if (persons == null || persons.Count == 0)
            {
                throw new ExceptionServices("No hay personas registradas.");
            }
            return persons;
        }

        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new ExceptionServices("La persona a agregar no puede ser nula.");
            }
            _personRepository.Add(person);
        }

        public void UpdatePerson(Person person)
        {
            if (person == null)
            {
                throw new ExceptionServices("La persona a actualizar no puede ser nula.");
            }
            _personRepository.Update(person);
        }

        public void DeletePerson(int id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                throw new ExceptionServices($"No se puede eliminar. No existe una persona con el ID {id}.");
            }
            _personRepository.Delete(person);
        }
    }