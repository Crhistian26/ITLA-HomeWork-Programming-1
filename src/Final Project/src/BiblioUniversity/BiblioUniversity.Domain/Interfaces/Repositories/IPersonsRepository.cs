using BiblioUniversity.Domain.Entities;
using BiblioUniversity.Domain.Interfaces.Repositories.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioUniversity.Domain.Interfaces.Repositories
{
    public interface IPersonsRepository : IBaseRepository<Person>
    {

    }
}
