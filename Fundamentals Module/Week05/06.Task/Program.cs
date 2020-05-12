using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            int count = firstHand.Count;


            while (true)
            {
                if (firstHand[0] > secondHand[0])
                {
                    firstHand.Add(firstHand[0]);
                    firstHand.Add(secondHand[0]);
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }

                else if (firstHand[0] < secondHand[0])
                {
                    secondHand.Add(secondHand[0]);
                    secondHand.Add(firstHand[0]);
                    secondHand.RemoveAt(0);
                    firstHand.RemoveAt(0);
                }



                else if (firstHand[0] == secondHand[0])
                {
                    secondHand.RemoveAt(0);
                    firstHand.RemoveAt(0);
                }

                if (firstHand.Count == 0)
                {
                    int sum = secondHand.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");
                    break;
                }
                else if (secondHand.Count == 0)
                {
                    int sum = firstHand.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");
                    break;
                }
            }
        }
    }
}
