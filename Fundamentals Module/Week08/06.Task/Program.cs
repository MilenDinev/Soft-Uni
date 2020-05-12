using System;
using System.Text;

namespace _06.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (i != input.Length - 1)
                {
                    if (input[i] != input[i + 1])
                    {
                        result.Append(input[i]);
                    }
                }

                else 
                {
                    result.Append(input[i]);
                }

            }

            Console.WriteLine(result);
        }
    }
}
