using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11MyFirstMVCApp.Models
{
    public class PersonOfTheYear
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public static List<PersonOfTheYear> GetPersons(int begYear, int endYear)
        {
            List<PersonOfTheYear> people = new List<PersonOfTheYear>(); //instantiates a new list, people, that holds PersonOfTheYear properties
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            string[] myFile = File.ReadAllLines(newPath);

            for (int i = 1; i < myFile.Length; i++) //iterates through each person
            {
                string[] fields = myFile[i].Split(',');
                people.Add(new PersonOfTheYear //add a new person to the list with person of the year attributes
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            List<PersonOfTheYear> listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();
            return listofPeople;//returns the list
        }
    }
}


