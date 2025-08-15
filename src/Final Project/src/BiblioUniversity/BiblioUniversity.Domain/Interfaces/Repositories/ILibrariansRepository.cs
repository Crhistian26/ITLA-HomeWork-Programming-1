using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories
{
    internal interface ILibrariansRepository : IBaseRepository<Librarian>
    {
        /// <summary>
        /// Metodo para obtener el <see cref="Librarian"/> por su ID de forma asincrona con todos los datos <see cref="Person"/> incluidos.
        /// </summary>
        /// <param name="id">Su id.</param>
        /// <returns>El <see cref="Librarian"/> (Con sus datos personales) que corresponda con el id.</returns>
        Task<Librarian> GetByIdWithPersonAsync(int id);

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="Librarian"/> con su campo <see cref="Person"/>
        /// </summary>
        /// <returns>Una <see cref="IEnumerable{T}"/> de <see cref="Librarian"/> con los datos mencionados</returns>
        Task<IEnumerable<Librarian>> GetAllWithPersonAsync();
    }
}
