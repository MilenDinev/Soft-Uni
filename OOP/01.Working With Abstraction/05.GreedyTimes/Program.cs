namespace _05.GreedyTimes
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {

            long bagCapacity = long.Parse(Console.ReadLine());
            string[] arguments = Console.ReadLine().Split();
            Bag bag = new Bag(bagCapacity);

            for (int i = 0; i < arguments.Length; i += 2)
            {
                string type = arguments[i];
                long amount = long.Parse(arguments[i + 1]);

                    Item item = new Item(type, amount);
                    bag.AddItem(item);
            }

            Console.WriteLine(bag);
        }
    }
}
