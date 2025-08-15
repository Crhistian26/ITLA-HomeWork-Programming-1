using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities.DataOnly
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navegation
        public IEnumerable<Book> Books { get; set; }
        public Author() { }
        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
