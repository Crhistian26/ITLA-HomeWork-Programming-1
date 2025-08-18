using BiblioUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.EntitiesDTOs
{
    public class LibrarianDTO
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string License { get; set; }

        public LibrarianDTO() { }

        public LibrarianDTO(Librarian librarian)
        {
            Id = librarian.Id;
            PersonId = librarian.PersonId;
            License = librarian.License;
        }

    }
}
