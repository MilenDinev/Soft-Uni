namespace DatingApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            Stack<int> males = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> females = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int matchCounter = 0;

            while (males.Any() && females.Any())
            {
                int currentMale = males.Peek();
                int currentFemale = females.Peek();


                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }

                if (currentFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }


                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    if (males.Any())
                    {
                        males.Pop();
                    }
                    continue;
                }

                if (currentFemale % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Any())
                    {
                        females.Dequeue();
                    }
                    continue;
                }

                if (currentMale == currentFemale)
                {
                    matchCounter++;
                    males.Pop();
                    females.Dequeue();
                    continue;
                }

                else if (currentMale != currentFemale)
                {
                    females.Dequeue();
                    int thisMale = males.Pop();
                    thisMale -= 2;
                    males.Push(thisMale);
                    continue;
                }
            }

            Console.WriteLine($"Matches: {matchCounter}");

            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }

            else if (!males.Any())
            {
                Console.WriteLine($"Males left: none");
            }

            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }

            else if (!females.Any())
            {
                Console.WriteLine($"Females left: none");
            }

        }
    }
}
