using PersonsIntoFiles.Models;
using PersonsIntoFiles.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonsIntoFiles.Repositories.Implementations
{
    internal class UserRepository : IReadRepository<Person>, IWriteRepository<Person>, IEqualityComparer<Person>,IDisposable
    {
        private Services.Security.FileInfo FileInfo { get; set; }
        private string JsonString => File.ReadAllText(FileInfo.GetPath);
        public UserRepository(Person person)
        {
            FileInfo = new Services.Security.FileInfo(person);
        }

        void IWriteRepository<Person>.ChangePerson(Person entity, string FilePath)
        {
            List<Person> Persons = JsonSerializer.Deserialize<List<Person>>(JsonString);
            foreach (var person in Persons)
            {
                if (Equals(person, entity))
                {
                    person.FirstName = entity.FirstName;
                    person.LastName = entity.LastName;
                    person.gender = entity.gender;
                    person.Age = entity.Age;
                    break;
                }
            }
        }
        public void Dispose()
        {
            FileInfo.Dispose();
        }
        void IWriteRepository<Person>.CreateFile(string FileName)
        {
            string FilePath = Console.ReadLine();
            FileInfo.CombinePath(FilePath);
           FileStream fs = File.Create(FileInfo.GetPath);
        }

        void IWriteRepository<Person>.DeleteFile(string FileName)
        {
            string Path = FileInfo.CombinePath(FileName);
            File.Delete(Path);
        }

        void IWriteRepository<Person>.WritePerson(Person entity,string FilePath)
        {
           string jsString = JsonSerializer.Serialize<Person>(entity, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(FileInfo.CombinePath(FilePath),jsString);
        }

        IEnumerable<Person> IReadRepository<Person>.GetAll()
        {
            List<Person> people = JsonSerializer.Deserialize<List<Person>>(JsonString);

            return people;
        }

        Person IReadRepository<Person>.GetPerson(int id)
        {
            List<Person> people = JsonSerializer.Deserialize<List<Person>>(JsonString);
            foreach (var item in people)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            throw new Exception("invalid Person id");
        }

        public bool Equals(Person x, Person y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Person obj)
        {
            return base.GetHashCode();
        }
    }
}
