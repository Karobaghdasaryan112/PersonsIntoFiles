using PersonsIntoFiles.Models;
using PersonsIntoFiles.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsIntoFiles.Repositories.Implementations
{
    internal class RepositoryFactory<T>
    {
        private Person _person;
       
        public RepositoryFactory(Person person)
        {
            _person = person;
        }
        private IWriteRepository<T> CreateWriteRepository()
        {
            if (_person.FileAccess == System.IO.FileAccess.Write)
            {
                return (IWriteRepository<T>)new UserRepository(_person);
            }
            throw new Exception("this Person cannot write");
        }
        private IReadRepository<T> CreateReadRepository()
        {
            return (IReadRepository<T>)new UserRepository(_person);
        }
        public IWriteRepository<T> GetWriteRepository()
        {
            return CreateWriteRepository();
        }
        public IReadRepository<T> GetReadRepository()
        {
            return CreateReadRepository();
        }
    }
}
