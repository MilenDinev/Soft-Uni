using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string gender = String.Empty;

                if (inputArgs.Length > 2)
                {
                    gender = inputArgs[2];
                }


                switch (animalType)
                {
                    case "Dog":
                        Dog dog = new Dog(name, age, gender);
                        Console.WriteLine(dog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(name, age, gender);
                        Console.WriteLine(cat);
                        break;
                    case "Frog":
                        Frog frog = new Frog(name, age, gender);
                        Console.WriteLine(frog);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(name, age);
                        Console.WriteLine(kitten);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(name, age);
                        Console.WriteLine(tomcat);
                        break;
                    default:
                        break;
                }

                animalType = Console.ReadLine();
            }
        }
    }
}
