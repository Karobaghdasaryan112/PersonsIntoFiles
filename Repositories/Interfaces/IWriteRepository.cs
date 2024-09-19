using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsIntoFiles.Repositories.Interfaces
{
    internal interface IWriteRepository<in T>
    {
        void WritePerson(T entity,string FilePath);
        void ChangePerson(T entity,string FilePath);
        void CreateFile(string FileName);
        void DeleteFile(string FileName);
    }
}
