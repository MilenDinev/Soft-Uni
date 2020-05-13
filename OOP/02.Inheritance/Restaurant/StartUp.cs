using System;

namespace Restaurant
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Food food = new Fish("Joro", 150);
            Console.WriteLine(food);
        }
    }
}
