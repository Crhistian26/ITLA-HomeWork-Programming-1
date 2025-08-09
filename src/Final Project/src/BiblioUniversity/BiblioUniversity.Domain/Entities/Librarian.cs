using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities
{
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
    }
}
