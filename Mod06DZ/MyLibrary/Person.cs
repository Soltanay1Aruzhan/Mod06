using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public static string GetPersonInfo(Person person)
        {
            return $"Name: {person.FirstName} {person.LastName}, Age: {person.Age}";
        }
    }

}
