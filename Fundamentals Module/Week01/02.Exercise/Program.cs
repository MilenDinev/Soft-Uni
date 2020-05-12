using System;

namespace _02.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int biggestdiv = 0;


            if (number % 2 == 0)
            {
                biggestdiv = 2;
            }

            if (number % 3 == 0)
            {
                biggestdiv = 3;
            }

            if (number % 6 == 0)
            {
                biggestdiv = 6;
            }

            if (number % 7 == 0)
            {
                biggestdiv = 7;
            }


            if (number % 10 == 0)
            {
                biggestdiv = 10;
            }

            if (number % 2 != 0 && number % 3 !=0 && number % 6 !=0 && number % 7 !=0 && number % 10 !=0)
            {
                Console.WriteLine("Not divisible");
            }

            else
            {
                Console.WriteLine($"The number is divisible by {biggestdiv}");
            }
            
        }
    }
}
