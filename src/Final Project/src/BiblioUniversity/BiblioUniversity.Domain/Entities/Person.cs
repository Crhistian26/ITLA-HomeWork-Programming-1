using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities
{
    [Index(nameof(Id_Card), IsUnique = true)]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        [StringLength(15)]
        public string Id_Card { get; set; }
        [Required]
        public string Address { get; set; }

        //Navegation
        public Student Student { get; set; }
        public Librarian Librarian { get; set; }
        public User User { get; set; }


        public Person() { }

        public Person( string name, string lastname, string telephone, string id_Card, string address)
        {
            Name = name;
            Lastname = lastname;
            Telephone = telephone;
            Id_Card = id_Card;
            Address = address;
        }
        public Person(int id,string name, string lastname, string telephone, string id_Card, string address) : this( name,  lastname,  telephone,  id_Card,  address)
        {
            Id = id;

        }
    }
}
