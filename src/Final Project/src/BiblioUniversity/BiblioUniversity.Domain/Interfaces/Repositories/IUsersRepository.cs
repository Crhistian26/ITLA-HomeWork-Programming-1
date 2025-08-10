using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Enum;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories
{
    public interface IUsersRepository : IBaseRepository<User>
    {
        Task<User> LoginAsync(string username, string password);
        Task<ICollection<User>> GetUsersForRol(Rol rol);
        Task<bool> ConfirmUserExists(string username);

    }
}
