using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
   public  class Startup
    {
        public static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string currentName = inputArgs[0];
                int currentAge = int.Parse(inputArgs[1]);

                if (currentAge > 30)
                {
                    Person person = new Person(currentName, currentAge);
                    if (!people.Contains(person))
                    {
                        people.Add(person);
                    }

                }

            }

            foreach (var member in people.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
