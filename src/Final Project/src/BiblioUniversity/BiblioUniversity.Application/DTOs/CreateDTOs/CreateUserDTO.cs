using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Application.DTOs.CreateDTOs
{
    public class CreateUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
        public int PersonId { get; set; }

        public CreateUserDTO() { }

        public CreateUserDTO(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Rol = user.Rol;
            PersonId = user.PersonId;
        }
    }

}
}
