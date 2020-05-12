using System;
using System.Linq;

namespace _09.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = string.Empty;

            while ( input != "Clone them!")
            {
                for (int i = 0; i < n; i++)
                {
                    int[] sequence =  Console.ReadLine().Split("!" ).Select(int.Parse).ToArray();
                }

                input = Console.ReadLine();
            }
        }
    }
}
