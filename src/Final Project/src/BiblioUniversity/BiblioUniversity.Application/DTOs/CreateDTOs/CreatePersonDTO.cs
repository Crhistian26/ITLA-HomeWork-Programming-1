using BiblioUniversity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.CreateDTOs
{
    public class CreatePersonDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Telephone { get; set; }
        public string Id_Card { get; set; }
        public string Address { get; set; }

        public CreatePersonDTO() { }

        public CreatePersonDTO(Person person)
        {
            Name = person.Name;
            Lastname = person.Lastname;
            Telephone = person.Telephone;
            Id_Card = person.Id_Card;
            Address = person.Address;
        }
    }
}
