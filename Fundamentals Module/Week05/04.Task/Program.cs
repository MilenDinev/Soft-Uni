using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();




            while (input != "End")
            {
                string[] operation = input.Split();

                if (operation[0] == "Add")
                {
                    numbers.Add(int.Parse(operation[1]));
                }

                if (operation[0] == "Insert")
                {
                   
                    if ((int.Parse(operation[2]) >= numbers.Count || int.Parse(operation[2]) < 0))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(operation[2]), int.Parse(operation[1]));
                    }
                }


                if (operation[0] == "Remove")
                {
                    if (int.Parse(operation[1]) >= numbers.Count | int.Parse(operation[1]) < 0 )
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(operation[1]));
                    }
                    
                }

                if (operation[1] == "left")
                {
                    for (int i = 0; i < int.Parse(operation[2]); i++)
                    {
                        int temp = numbers[0];
                        numbers.RemoveAt(0);
                        numbers.Add(temp);
                    }
                }

                if (operation[1] == "right")
                {
                    for (int i = 0; i < int.Parse(operation[2]); i++)
                    {
                        int temp = numbers[numbers.Count-1];
                        numbers.RemoveAt(numbers.Count-1);
                        numbers.Insert(0, temp);

                    }
                }

                input = Console.ReadLine();

            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
