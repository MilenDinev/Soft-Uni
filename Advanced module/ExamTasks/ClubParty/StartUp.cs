namespace ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            int hallsCapacity = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> reservations = new Dictionary<string, List<int>>();
            Stack<string> input = new Stack<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Queue<string> halls = new Queue<string>();

            while (input.Any())
            {
                string currentElement = input.Peek();

                if (!char.IsDigit(currentElement[0]))
                {
                    reservations[currentElement] = new List<int>();
                    halls.Enqueue(currentElement);
                    input.Pop();
                    continue;
                }

                if (!reservations.Any())
                {
                    input.Pop();
                    continue;
                }

                foreach (var hall in reservations)
                {
                    int currentReservation = int.Parse(currentElement);

                    if (hall.Value.Sum() + currentReservation  <= hallsCapacity)
                    {
                        reservations[hall.Key].Add(currentReservation);
                        input.Pop();
                        break;
                    }

                    if (hall.Value.Sum() + currentReservation >= hallsCapacity && halls.Any())
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", hall.Value)}");
                        reservations.Remove(hall.Key);
                    }

                    break;

                }
            }
        }
    }
}
