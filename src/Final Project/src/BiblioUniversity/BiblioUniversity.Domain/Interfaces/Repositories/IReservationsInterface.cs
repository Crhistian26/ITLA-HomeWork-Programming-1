using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories
{
    public interface IReservationsInterface : IBaseRepository<Reservation>
    {
        /// <summary>
        /// Este metodo te devuelve un <see cref="Reservation"/> con sus campos de <see cref="Student"/> y <see cref="Book"/>.
        /// </summary>
        /// <param name="id">Su id.</param>
        /// <returns>Un <see cref="Reservation"/> con los datos mencionados.</returns>
        Task<Reservation> GetByIdWithStudentBook(int id);

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="Reservation"/> con sus campos de <see cref="Student"/> y <see cref="Book"/>.
        /// </summary>
        /// <returns>Un <see cref="IEnumerable{Reservation}"/> de <see cref="Reservation"/> con los datos mencionados.</returns>
        Task<IEnumerable<Reservation>> GetAllWithStudentBook();

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="Reservation"/> con sus campos de <see cref="Student"/> y <see cref="Book"/> filtrados por su <see cref="Student"/>.
        /// </summary>
        /// <param name="student">El estudiante por el cual se va a filtrar.</param>
        /// <returns>Una <see cref="IEnumerable{Reservation}"/> filtrada de <see cref="Reservation"/> con los datos mencionados.</returns>
        Task<IEnumerable<Reservation>> GetAllWithStudentBookForStudent(Student student);

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="Reservation"/> con sus campos de <see cref="Student"/> y <see cref="Book"/> filtrados por su <see cref="Book"/>.
        /// </summary>
        /// <param name="book">El libro por el cual se va a filtrar.</param>
        /// <returns>Una <see cref="IEnumerable{Reservation}"/> filtrada de <see cref="Reservation"/> con los datos mencionados.</returns>
        Task<IEnumerable<Reservation>> GetAllWithStudentBookForBook(Book book);
    }
}
