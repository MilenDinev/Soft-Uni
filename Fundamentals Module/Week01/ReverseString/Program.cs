using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int inputLength = input.Length;

            string newWord = string.Empty;

            for (int i = inputLength - 1; i >=  0; i--)
            {
                newWord += input[i];
            }

            Console.WriteLine(newWord);
        }
    }
}
