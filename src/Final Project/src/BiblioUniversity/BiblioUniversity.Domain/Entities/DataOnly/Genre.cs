using BiblioUniversity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities.DataOnly
{
    [Index(nameof(Name), IsUnique = true)]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //Navegation
        public IEnumerable<Book> Books { get; set; }

        public Genre() { }
        public Genre(int id, string name)
        { 
            Id = id;
            Name = name;
        }

    }
}
