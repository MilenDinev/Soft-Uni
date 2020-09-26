namespace FlowerWreaths
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wreath = 15;
            int wreathCounter = 0;
            int flowersLeft = 0;

            while (lilies.Any() && roses.Any())
            {
                if (lilies.Peek() + roses.Peek() == wreath)
                {
                    wreathCounter++;

                    lilies.Pop();
                    roses.Dequeue();

                    continue;
                }

                if (lilies.Peek() + roses.Peek() < wreath)
                {
                    flowersLeft += lilies.Pop() + roses.Dequeue();
                    continue;
                }

                if (lilies.Peek() + roses.Peek() > wreath)
                {
                    while (lilies.Peek() + roses.Peek() > wreath)
                    {
                        int currentLilie = lilies.Pop() - 2;
                        lilies.Push(currentLilie);

                        if (lilies.Peek() + roses.Peek() == wreath)
                        {
                            wreathCounter++;

                            lilies.Pop();
                            roses.Dequeue();

                            break;
                        }

                        if (lilies.Peek() + roses.Peek() < wreath)
                        {
                            flowersLeft += lilies.Pop() + roses.Dequeue();
                            break;
                        }

                    }
                }
            }


            wreathCounter += flowersLeft / 15;

            if (wreathCounter >= 5)
            {
                Console.WriteLine("You made it, you are going to the competition with 5 wreaths!");
            }

            else if (wreathCounter < 5)
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCounter} wreaths more!");
            }
        }
    }
}

