using System;
using System.Text;

namespace _04.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder(Console.ReadLine());



            for (int i = 0; i < message.Length; i++)
            {
                message[i] += (char)3;
            }

            Console.WriteLine(message);
        }
    }
}
