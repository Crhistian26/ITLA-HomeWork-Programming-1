using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities.DataOnly
{
    public class Genre
    {
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
