using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersAsString = Console.ReadLine().Split('|').Reverse().ToList();
            List<int> numbers = new List<int>();
            foreach (var item in numbersAsString)
            {
                numbers.AddRange(item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
