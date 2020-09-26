namespace Lootbox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int claimedItems = 0;

            while (firstBox.Any() && secondBox.Any())
            {
                int sum = firstBox.Peek() + secondBox.Peek();

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                    continue;
                }

                else
                {
                    int removedItem = secondBox.Pop();
                    firstBox.Enqueue(removedItem);
                    continue;
                }
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            else if (!secondBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }

            else if (claimedItems < 100)
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
