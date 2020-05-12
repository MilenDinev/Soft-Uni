using System;

namespace _05.PrintASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            for (int i = n; i <= y; i++)
            {
                Console.Write((char)i +" ");
            }
        }
    }
}
