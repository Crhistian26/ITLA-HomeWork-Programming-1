using BiblioUniversity.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Rol Rol { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public User() { }   

        public User(int id, string username, string password, Rol rol, Person person)
        {
            Id = id;
            Username = username;
            Password = password;
            Rol = rol;
            Person = person;
        }

        public User(int id, string username, string password, Rol rol, int personid)
        {
            Id = id;
            Username = username;
            Password = password;
            Rol = rol;
            PersonId = personid;
        }
        public User(string username, string password, Rol rol, int personid)
        {
            Username = username;
            Password = password;
            Rol = rol;
            PersonId = personid;
        }
    }
}
