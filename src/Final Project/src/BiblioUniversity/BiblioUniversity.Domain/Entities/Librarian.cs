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
    [Index(nameof(License), IsUnique = true)]
    [Index(nameof(PersonId), IsUnique = true)]
    public class Librarian
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        public string License { get; set; }
           

        public Librarian() { }

        public Librarian(int id, Person person, string license)
        {
            Id = id;
            Person = person;
            License = license;
        }

        public Librarian(int id, int personid, string license)
        {
            Id = id;
            PersonId = personid;
            License = license;
        }
    }
}
