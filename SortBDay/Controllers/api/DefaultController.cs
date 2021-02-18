using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Text;
using SortBDay.Models;

namespace SortBDay.Controllers.api
{
    public class DefaultController : ApiController
    {
        private List<string> details = null;
        private List<Person> person = null;
        private string fileLocation = @"C:\Dev\Dev\C#\Employement Test\React\SampleFilecsv.csv";

        [HttpGet]
        public List<Person> GetInitialList()
        {
            
            person = new List<Person>();
            try {
            details = File.ReadLines(fileLocation).ToList<string>();
            details.RemoveAt(0);

            person = CalculateAge(details);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

            person.Sort();

            return person;
        }

        [HttpPost]
        public void AddPerson(Person person)
        {

            string lineToAdd = default;
            string fileLocation = @"C:\Dev\Dev\C#\Employement Test\React\SampleFilecsv.csv";

            lineToAdd = $"{person.Name};{person.Surname};{person.Birthday}";
            lineToAdd += Environment.NewLine;

            if(File.Exists(fileLocation))
            {
                File.AppendAllText(fileLocation, lineToAdd);
            }
            else
            {
                File.WriteAllText(fileLocation, lineToAdd);
            }      
        }


        [NonAction]
        public List<Person> CalculateAge(List<string> info)
        {
            int age = default;
            DateTime currentDate = DateTime.Now;
            DateTime birthday = default;

            List<Person> people = new List<Person>();
            SortedList<string, string> sortList = new SortedList<string, string>();

            decimal averageAge = default;
            int count = default;
            int ageSum = default;

            count = info.Count;

            foreach (string line in info)
            {
                string[] items = line.Split(';');

                string name = items[0];
                string surname = items[1];
                bool isBirthDate =  DateTime.TryParse(items[2],out birthday);

                age = Convert.ToInt16(currentDate.Year - birthday.Year);

                ageSum = ageSum + age;
                averageAge = ageSum / count;

                Person person = new Person()
                {
                    Age = age,
                    Name = name,
                    Surname = surname,
                    Birthday = birthday.ToShortDateString()
                };
                
                people.Add(person);

            }

            return people;

        }
    }
}
