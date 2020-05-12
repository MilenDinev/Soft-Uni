using System;

namespace _01.Task
{
    class Program
    {

        static double SmallestNum(double a, double b, double c)
        {
            double smallestNum = 0;
            if (a <= b && a <= c)
            {
                smallestNum = a;
            }

            else if (b <= a && b <= c)
            {
                smallestNum = b;
            }

            else if (c <= a && c <= b)
            {
                smallestNum = c;
            }


            return smallestNum;
        }
        static void Main(string[] args)

        {
            double a = double.Parse(Console.ReadLine());
            double b= double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine(SmallestNum(a, b, c));
        }
    }
}
