using System;

namespace _03.Task
{
    class Program
    {

        static void CharacterInRange(char start, char end)
        {

            if (start < end)
            {
                for (char i = start; i < end - 1; i++)
                {
                    Console.Write((char)(i + 1) + " ");
                }
            }

            else if (start > end)
            {
                for (char i = end; i < start - 1; i++)
                {
                    Console.Write((char)(i + 1) + " ");
                }
            }

        }
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            CharacterInRange(start, end);
        }
    }
}
