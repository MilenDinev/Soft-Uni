namespace Restaurant
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            Food food = new Fish("Joro", 150);
            Console.WriteLine(food);
        }
    }
}
