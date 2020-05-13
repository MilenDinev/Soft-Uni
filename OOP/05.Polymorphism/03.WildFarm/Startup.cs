using _03.WildFarm.Animals;
using _03.WildFarm.Animals.Birds;
using _03.WildFarm.Animals.Mammals;
using _03.WildFarm.Animals.Mammals.Felines;
using _03.WildFarm.Factories;
using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _03.WildFarm
{
    public class Startup
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command.Split();

                Animal animal = AnimalFactory.Create(commandArgs);

                string[] foodEaten = Console.ReadLine().Split();

                Food food = FoodFactory.Create(foodEaten);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);

                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
