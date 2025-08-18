using BiblioUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.CreateDTOs
{
    public class CreateLibrarianDTO
    {
        public int PersonId { get; set; }
        public string License { get; set; }

        public CreateLibrarianDTO() { }

        public CreateLibrarianDTO(Librarian librarian)
        {
            PersonId = librarian.PersonId;
            License = librarian.License;
        }
    }
}
