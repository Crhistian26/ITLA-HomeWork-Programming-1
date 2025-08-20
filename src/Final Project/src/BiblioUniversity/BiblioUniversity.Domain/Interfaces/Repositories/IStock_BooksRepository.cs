using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories
{
    public interface IStock_BooksRepository : IBaseRepository<Stock_Book>
    {
        /// <summary>
        /// Metodo para obtener el <see cref="Stock_Book"/> por su ID de forma asincrona con todos los datos <see cref="Book"/> incluidos.
        /// </summary>
        /// <param name="id">Su id.</param>
        /// <returns>El <see cref="Stock_Book"/> (Con los datos del libro) que corresponda con el id.</returns>
        Task<Stock_Book> GetByIdWithAllBookDataAsync(int id);

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="Stock_Book"/> con su campo <see cref="Book"/>.
        /// </summary>
        /// <returns>Una <see cref="IEnumerable{T}"/> de <see cref="Stock_Book"/> con los datos mencionados.</returns>
        Task<IEnumerable<Stock_Book>> GetAllWithAllDataAsync();

        Task<Stock_Book> GetByBookId(int id);
    }
}
