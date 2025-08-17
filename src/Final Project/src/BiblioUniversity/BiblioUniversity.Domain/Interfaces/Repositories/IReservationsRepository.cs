using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories
{
    public interface IReservationsRepository : IBaseRepository<Reservation>
    {
        /// <summary>
        /// Este metodo te devuelve un <see cref="Reservation"/> con sus campos de <see cref="Student"/> y <see cref="Book"/>.
        /// </summary>
        /// <param name="id">Su id.</param>
        /// <returns>Un <see cref="Reservation"/> con los datos mencionados.</returns>
        Task<Reservation> GetByIdWithStudentBookAsync(int id);

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="Reservation"/> con sus campos de <see cref="Student"/> y <see cref="Book"/>.
        /// </summary>
        /// <returns>Un <see cref="IEnumerable{Reservation}"/> de <see cref="Reservation"/> con los datos mencionados.</returns>
        Task<IEnumerable<Reservation>> GetAllWithStudentBook();
    }
}
