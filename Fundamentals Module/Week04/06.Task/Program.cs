using System;

namespace _06.Task
{
    class Program
    {
        static void MiddleChar(string word)
        {
            if (word.Length % 2 == 0)
            {
                Console.WriteLine($"{(char)word[word.Length / 2 - 1]}{(char)word[word.Length / 2]}");
            }
            else
            {
                Console.WriteLine(($"{(char)word[word.Length / 2]}"));
            }
        }
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            MiddleChar(word);
        }
    }
}
