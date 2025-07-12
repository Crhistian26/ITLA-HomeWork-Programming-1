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
    internal class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public Contact GetContact(int id)
        {
            return _contactRepository.GetById(id);
        }
        public Contact GetContact(string name)
        {
            return _contactRepository.GetByName(name);
        }
        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAll();
        }
        public bool AddContact(Contact contact)
        {
            return _contactRepository.Add(contact);
        }
        public bool UpdateContact(Contact contact)
        {
            return _contactRepository.Update(contact);
        }
        public bool DeleteContact(int id)
        {
            return _contactRepository.Delete(id);
        }


    }
}
