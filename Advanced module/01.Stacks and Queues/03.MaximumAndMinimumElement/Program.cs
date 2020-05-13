using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();



            for (int i = 0; i < rotations; i++)
            {
                string[] input = Console.ReadLine().Split();

                switch (input[0])
                {
                    case "1":
                        stack.Push(int.Parse(input[1]));
                        break;
                    case "2":
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }                  
                        break;
                    case "3":
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }

                        break;
                    case "4":
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
