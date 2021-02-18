using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SortBDay.Models
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public int Age { get; set; }
     

        public int CompareTo(Person person)
        {
            return Age - person.Age;
        }
    }
}