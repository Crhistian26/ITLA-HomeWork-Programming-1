using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Entities.DataOnly;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        /// <summary>
        /// Este metodo te devuelve un <see cref="Book"/> con sus campos de <see cref="Author"/>, <see cref="Language"/>, <see cref="Genre"/> y <see cref="Stock_Book"/>.
        /// </summary>
        /// <param name="id">Su id.</param>
        /// <returns>Un <see cref="Book"/> con los datos mencionados.</returns>
        Task<Book> GetByIdWithAllDataAsync(int id);

        /// <summary>
        /// Este metodo te devuelve una coleccion de <see cref="Book"/> con sus campos de <see cref="Author"/>, <see cref="Language"/>, <see cref="Genre"/> y <see cref="Stock_Book"/>.
        /// </summary>
        /// <returns>Un <see cref="IEnumerable{Book}"/> de <see cref="Book"/> con los datos mencionados.</returns>
        Task<IEnumerable<Book>> GetAllWithAllDataAsync();



    }
}
