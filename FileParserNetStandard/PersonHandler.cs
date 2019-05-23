//using ObjectLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FileParserNetStandard
{

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
        public Person(int id, string firstName, string surname, DateTime dob)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            Dob = dob;
        }
        public override string ToString()
        {
            return FirstName + " "
                + Surname + " "
                + Dob.ToShortDateString()
                + " " + Dob.ToLongTimeString() + "/"
                + Dob.ToShortDateString().Substring(3, Dob.ToShortDateString().Length - 3);
        }
    }  

    public class PersonHandler
    {
        public List<Person> People = new List<Person>();
        DataParser dp = new DataParser();
        FileHandler fh = new FileHandler();

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            foreach (var person in people)
            {
                People.Add(new Person(int.Parse(person[0]), person[1], person[2], new DateTime(long.Parse(person[3]))));
            }
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            return People.Where(x => x.Dob == People.Min(y => y.Dob)).ToList();
            //return new List<Person>(); //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id)
        {

            return People.Where(x => x.Id == id).First().ToString();  //-- return result here
        }

        public List<Person> GetOrderBySurname()
        {
            return People.OrderBy(x => x.Surname).ToList();
            //return new List<Person>();  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive)
        {
            if (caseSensitive)
            {
                return People.Where(x => x.Surname.StartsWith(searchTerm)).Count();
            }
            return People.Count(x => x.Surname.ToLower().StartsWith(searchTerm.ToLower()));
            //return 0;  //-- return result here
        }

        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate()
        {
            List<string> result = new List<string>();
            var _People = People.GroupBy(x => x.Dob).OrderBy(x => x.Key);
            foreach (var person in _People)
            {
                result.Add(person.Key.ToString() + "\t" + person.Count());
            }
            return result;  //-- return result here
        }
    }
}