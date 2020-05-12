//03.Last Stop

/*       */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input!="END")
            {

                string[] commandArgs = input.Split();

                if (commandArgs[0] == "Change")
                {
                    if (numbers.Contains(int.Parse(commandArgs[1])))
                    {
                        int index = numbers.IndexOf(int.Parse(commandArgs[1]));

                        numbers[index] = int.Parse(commandArgs[2]);
                    }
                }

                if (commandArgs[0] == "Hide" )
                {
                    if (numbers.Contains(int.Parse(commandArgs[1])))
                    {
                        while(numbers.Contains(int.Parse(commandArgs[1])))
                        {
                            numbers.Remove(int.Parse(commandArgs[1]));
                        }

                    }
                }

                if (commandArgs[0] == "Switch")
                {
                    if (numbers.Contains(int.Parse(commandArgs[1])) && numbers.Contains(int.Parse(commandArgs[2])))
                    {
                        int indexOfFirst = numbers.IndexOf(int.Parse(commandArgs[1]));
                        int indexOfSecond = numbers.IndexOf(int.Parse(commandArgs[2]));

                        numbers[indexOfFirst] = int.Parse(commandArgs[2]);
                        numbers[indexOfSecond] = int.Parse(commandArgs[1]);
                    }
                }

                if (commandArgs[0] == "Insert")
                {
                    if (int.Parse(commandArgs[1]) < numbers.Count - 1)
                    {
                        numbers.Insert(int.Parse(commandArgs[1]) + 1, int.Parse(commandArgs[2]));
                    }
                }

                if (commandArgs[0] == "Reverse")
                {
                    numbers.Reverse();
                }



                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
