using System;
using System.Collections.Generic;


namespace _01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < rotations; i++)
            {
                string name = Console.ReadLine();

                uniqueNames.Add(name);
            }


            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
