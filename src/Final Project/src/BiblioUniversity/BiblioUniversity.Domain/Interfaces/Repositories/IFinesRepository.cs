using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories
{
    public interface IFinesRepository : IBaseRepository<Fine>
    {
        /// <summary>
        /// Metodo para obtener el <see cref="Fine"/> por su ID de forma asincrona con todos los datos de la reservacion incluidos.
        /// </summary>
        /// <param name="id">Su id.</param>
        /// <returns>La <see cref="Fine"/> (Con los datos de reservacion) que corresponda con el id.</returns>
        Task<Fine> GetByIdWithReservationAsync(int id);

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="Fine"/> con su campo <see cref="Reservation"/>.
        /// </summary>
        /// <returns>Una <see cref="IEnumerable{T}"/> de <see cref="Fine"/> con los datos mencionados.</returns>
        Task<IEnumerable<Fine>> GetAllWithReservationAsync();
    }
}
