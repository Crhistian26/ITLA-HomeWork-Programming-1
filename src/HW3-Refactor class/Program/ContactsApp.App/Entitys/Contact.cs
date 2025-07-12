using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactsApp.App.Entitys
{
    internal class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool BestFriends { get; set; }
        public Contact(int id, string name, string lastname, string phone, string address, string email, int age, bool bestfriends)
        {
            ID = id;
            Name = name;
            LastName = lastname;
            Phone = phone;
            Address = address;
            Email = email;
            Age = age;
            BestFriends = bestfriends;
        }


    }
}
