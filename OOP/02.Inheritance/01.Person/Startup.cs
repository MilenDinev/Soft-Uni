using System;

namespace _01.Person
{
    public class Startup
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());


            Person person;

            if (age > 15)
            {
                person = new Person(name, age);
                Console.WriteLine(person);
            }

            else if (age <= 15)
            {
                person = new Child(name, age);
                Console.WriteLine(person);
            }

            

        }
    }
}
