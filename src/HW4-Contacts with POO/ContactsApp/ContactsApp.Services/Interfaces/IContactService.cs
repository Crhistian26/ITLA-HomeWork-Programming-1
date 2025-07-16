using ContactsApp.Domain.Entitys;
using ContactsApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Services.Interfaces
{
    public interface IContactService
    { 
        Contact GetContact(int id);
        Contact GetContact(string name);
        List<Contact> GetAllContacts();
        bool AddContact(Contact contact);
        bool UpdateContact(Contact contact);
        bool DeleteContact(int id);
        bool VerifyId(int id);

    }
}
