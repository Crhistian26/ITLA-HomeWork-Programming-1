using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Entities.DataOnly
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navegation
        public IEnumerable<Book> Books { get; set; }

        public Language() { }

        public Language(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
