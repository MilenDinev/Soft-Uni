using System;

namespace DefiningClasses
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("Georgi", 25);

            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
