using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories
{
    public interface IStudentsRepository : IBaseRepository<Student>
    {
        /// <summary>
        /// Metodo para obtener el <see cref="Student"/> por su ID de forma asincrona con todos los datos <see cref="Person"/> incluidos.
        /// </summary>
        /// <param name="id">Su id.</param>
        /// <returns>El <see cref="Student"/> (Con sus datos personales) que corresponda con el id.</returns>
        Task<Student> GetByIdWithPersonAsync(int id);

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="Student"/> con su campo <see cref="Person"/>.
        /// </summary>
        /// <returns>Una <see cref="IEnumerable{T}"/> de <see cref="Student"/> con los datos mencionados.</returns>
        Task<IEnumerable<Student>> GetAllWithPersonAsync();
    }
}
