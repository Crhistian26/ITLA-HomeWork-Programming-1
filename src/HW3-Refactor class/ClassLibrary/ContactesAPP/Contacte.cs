using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Contacte
    {
        public string Name {  get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string Telefone { get; set; }
        public string? Emails { get; set; }
        public int Age { get; set; }
        public bool BestFriends {  get; set; }

        public Contacte()
        {

        }
        public Contacte(string name, string? lastName, string? address, string telefone, string? emails, int age, bool bestFriends)
        {
            Name = name;
            LastName = lastName;
            Address = address;
            Telefone = telefone;
            Emails = emails;
            Age = age;
            BestFriends = bestFriends;
        }
    }
}
