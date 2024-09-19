using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsIntoFiles.Repositories.Interfaces
{
    internal interface IReadRepository<out T>
    {
        T GetPerson(int id);
        IEnumerable<T> GetAll();

    }
}
