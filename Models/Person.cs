using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsIntoFiles.Models
{
    internal enum Gender
    {
        None,
        Male,
        Female,
    }
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender gender { get; set; }
        public FileAccess FileAccess { get; set; }
        public Person() { }
        public Person(int id, string firstName, string lastName, int age, Gender gender,FileAccess fileAccess)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            this.gender = gender;
           FileAccess = fileAccess;
        }
    }
}
