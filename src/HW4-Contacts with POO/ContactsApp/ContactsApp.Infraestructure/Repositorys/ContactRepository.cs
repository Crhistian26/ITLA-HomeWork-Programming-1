using ContactsApp.Domain.Entitys;
using ContactsApp.Infraestructure.Interfaces;

namespace ContactsApp.Infraestructure.Repositorys
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly List<Contact> _contacts;
        public ContactRepository() 
        {
            //Test Data
            _contacts = new List<Contact>()
            {
                new Contact(1, "Juan", "Perez", "8098867568", "Los Alcarrizos", "Juan@gmail.com", 17, false),
                new Contact(2, "Maria", "Gomez", "8294561234", "Santo Domingo Este", "maria.gomez@example.com", 25, true),
                new Contact(3, "Carlos", "Lopez", "8497853698", "Villa Mella", "c.lopez@gmail.com", 30, false),
                new Contact(4, "Ana", "Martinez", "8293345678", "La Vega", "ana_mtz@hotmail.com", 22, true),
                new Contact(5, "Pedro", "Sanchez", "8092231199", "San Cristóbal", "pedro.s@example.com", 40, false),
                new Contact(6, "Luisa", "Fernandez", "8497784521", "Boca Chica", "luisa.fdz@gmail.com", 29, true)
            };

        }

        public Contact GetByName(string name)
        {
            Contact c;
            c = _contacts.Where(c => c.Name == name).FirstOrDefault();
            return c;
        }
        public List<Contact> GetAll()
        {
            return _contacts;
        }
        public Contact GetById(int Id)
        {
            Contact c;
            c = _contacts.Where(c=> c.ID == Id).FirstOrDefault();
            return c;
        }

        public bool Add(Contact c)
        {
            c.ID = _contacts.FindLast(c=> c.Name != null).ID + 1;

            if(c.ID < 0)
            {
                return false;
            }
            
            _contacts.Add(c);

            return true;

        }

        public bool Update(Contact contact)
        {
            int position = _contacts.FindIndex(0, c => c.ID == contact.ID);

            if(position < 0)
            {
                return false;
            }

            _contacts[position] = contact;
            return true;

        }
        public bool Delete(int Id)
        {
            int position = _contacts.FindIndex(0, c => c.ID == c.ID);

            if(position < 0)
            {
                return false;
            }

            _contacts.RemoveAt(position);
            return true;
        }

        public bool VerifyId(int Id)
        {
            int position = _contacts.FindIndex(0, c => c.ID == Id);

            if(position < 0)
            {
                return false;
            }

            return true;
        }
    }
}
