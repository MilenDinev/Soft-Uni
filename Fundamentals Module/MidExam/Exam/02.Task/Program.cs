using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] numbersArgs = input.Split();


                if (numbersArgs[0] == "Switch")
                {
                    if (int.Parse(numbersArgs[1]) <= numbers.Count - 1 && int.Parse(numbersArgs[1]) >= 0)
                    {
                        numbers[int.Parse(numbersArgs[1])] -= 2 * numbers[int.Parse(numbersArgs[1])];
                    }
                }

                else if (numbersArgs[0] == "Change")
                {
                    if (int.Parse(numbersArgs[1]) <= numbers.Count - 1 && int.Parse(numbersArgs[1]) >= 0)
                    {
                        int index = int.Parse(numbersArgs[1]);

                        numbers[index] = int.Parse(numbersArgs[2]);
                    }
                }

                else if (numbersArgs[1] == "Negative")
                {
                    int sumNegative = 0;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] < 0)
                        {
                            sumNegative += numbers[i];
                        }
                    }

                    Console.WriteLine(sumNegative);
                }

                else if (numbersArgs[1] == "Positive")
                {
                    int sumPositive = 0;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] > 0)
                        {
                            sumPositive += numbers[i];
                        }
                    }

                    Console.WriteLine(sumPositive);
                }

                else if (input == "Sum All")
                {
                    Console.WriteLine(numbers.Sum()); 
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= 0)
                {
                    if (i != numbers.Count - 1)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                    else
                    {
                        Console.Write(numbers[i]);
                    }
                    
                }
            }

            Console.WriteLine();
            
        
        }
    }
}
