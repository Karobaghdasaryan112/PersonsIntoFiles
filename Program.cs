using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using PersonsIntoFiles.Models;
using PersonsIntoFiles.Repositories.Implementations;
using PersonsIntoFiles.Repositories.Interfaces;
namespace PersonsIntoFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person()
            {
                FirstName = "some",
                LastName = "some",
                Age = 10,
                Id = 1,
                gender = Gender.Male,
                FileAccess = FileAccess.Write,
            };
            RepositoryFactory<Person> repositoryFactory = new RepositoryFactory<Person>(person);
            IWriteRepository<Person> user = repositoryFactory.GetWriteRepository();

            user.WritePerson(person,"SomeFile.txt");
            ((UserRepository)user).Dispose();
            Console.ReadLine();

        }
    }
}
