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
        /// <summary>
        /// Metodo para obtener el <see cref="User"/> por su ID de forma asincrona con todos los datos <see cref="Person"/> incluidos.
        /// </summary>
        /// <param name="id">Su id.</param>
        /// <returns>El <see cref="User"/> (Con sus datos personales) que corresponda con el id.</returns>
        Task<User> GetWithPersonByIdAsync(int id);

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="User"/> con su campo <see cref="Person"/>.
        /// </summary>
        /// <returns>Una <see cref="IEnumerable{T}"/> de <see cref="User"/> con los datos mencionados.</returns>
        Task<IEnumerable<User>> GetAllWithPersonAsync();

        /// <summary>
        /// Este metodo te devuelve el usuario que tiene el mismo correo y contraseña ingresados, en caso de no existir uno, te devuelve nulo.
        /// </summary>
        /// <param name="username">El nombre de usuario.</param>
        /// <param name="password">La contraseña.</param>
        /// <returns>Un <see cref="User"/> que corresponde a los datos ingresados</returns>
        Task<User> LoginAsync(string username, string password);

        /// <summary>
        /// Este metodo se encarga de verificar si un nombre de usuario existe, y te devuelve un <see cref="bool"/> en consecuencia.
        /// </summary>
        /// <param name="username">El nombre de usuario.</param>
        /// <returns>Un <see cref="bool"/> si existe sera True sino sera False.</returns>
        Task<bool> ConfirmUserExists(string username);

    }
}
