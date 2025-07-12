using ContactsApp.Domain.Entitys;
using ContactsApp.Infraestructure.Interfaces;

namespace ContactsApp.Infraestructure.Repositorys
{
    public class ContactRepository : IRepository<Contact>
    {
        public ContactRepository() { }

        public Contact Get()
        {
            return null;
        }

        public List<Contact> GetAll()
        {
            return null;
        }

        public Contact GetById(int Id)
        {
            return null;
        }

        public bool Add(Contact c)
        {
            return false;
        }

        public bool Update(Contact c)
        {
            return false;
        }
        public bool Delete(Contact c)
        {
            return false;
        }

        public bool DeleteById(int Id)
        {
            return false;
        }
    }
}
