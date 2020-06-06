using System;
using System.Linq;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split().ToArray();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                Person currentPerson = new Person(name, age);
                family.AddMember(currentPerson);
                
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age} ");
        }
    }
}
