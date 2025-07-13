using ContactsApp.Infraestructure;
using ContactsApp.Services.Interfaces;
using ContactsApp.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp.Domain.Entitys;

namespace ContactsApp.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public Contact GetContact(int id)
        {
            Contact c;
            c = _contactRepository.GetById(id);

            if (c == null)
            {
                throw new Exception("No existe un contacto con ese ID");
            }

            return c;
        }
        public Contact GetContact(string name)
        {
            Contact c;
            c = _contactRepository.GetByName(name);

            if (c == null)
            {
                throw new Exception("No existe un contacto con ese nombre");
            }

            return c;
        }
        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAll();
        }
        public bool AddContact(Contact contact)
        {
            if(_contactRepository.GetAll().Any(c => c.Name == contact.Name && c.LastName == contact.LastName))
            {
                throw new Exception("Ya existe un contacto con el mismo nombre y apellido");
            }

            if(_contactRepository.GetAll().Any(c => c.Email == contact.Email))
            {
                throw new Exception("Ya existe un contacto con el mismo apellido");
            }

            return _contactRepository.Add(contact);

        }
        public bool UpdateContact(Contact contact)
        {
            if(_contactRepository.GetById(contact.ID) == null)
            {
                throw new Exception("No existe un contacto con ese ID");
            }

            return _contactRepository.Update(contact);
        }
        public bool DeleteContact(int id)
        {
            if(_contactRepository.GetById(id) == null)
            {
                throw new Exception("No existe un contacto con ese ID");
            }
            
            return _contactRepository.Delete(id);
        }


    }
}
