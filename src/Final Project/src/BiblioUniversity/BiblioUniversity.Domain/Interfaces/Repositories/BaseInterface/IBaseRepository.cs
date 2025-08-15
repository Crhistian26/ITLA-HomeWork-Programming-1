using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Metodo para obtener el <typeparamref name="T"/> por su ID de forma asincrona.
        /// </summary>
        /// <param name="id">Su id.</param>
        /// <returns>La <typeparamref name="T"/> que corresponda con el id.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Metodo para obtener todos los <typeparamref name="T"/> de forma asincrona.
        /// </summary>
        /// <returns>Una <see cref="IEnumerable{}"/> de <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Metodo para agregar un <typeparamref name="T"/> al sistema de forma asincrona.
        /// </summary>
        /// <param name="entity">EL <typeparamref name="T"/> a agregar.</param>
        /// <returns>El <typeparamref name="T"/> por si es necesario posteriormente.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Metodo para actualizar un <typeparamref name="T"/> de forma asincrona.
        /// </summary>
        /// <param name="entity">EL <typeparamref name="T"/> a modificar.</param>
        /// <returns>El <typeparamref name="T"/> por si es necesario posteriormente.</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Metodo para eliminar un <typeparamref name="T"/> de forma asincrona, mediante la propia entidad.
        /// </summary>
        /// <param name="entity">EL <typeparamref name="T"/> a eliminar.</param>
        /// <returns>No retorna nada.</returns>
        Task DeleteAsync(T entity);
    }
}
