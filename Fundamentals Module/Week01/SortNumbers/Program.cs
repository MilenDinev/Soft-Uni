using System;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int biggest = 0;
            int medium = 0;
            int smallest = 0;

            if (a > b && b > c || a == b || b == c )
            {
                biggest = a;
                medium = b;
                smallest = c;
                

            }
            else if (a > c && c > b  || b == c)
            {
                biggest = a;
                medium = c;
                smallest = b;
            }
            else if (b > a && a > c || a == b || c == a)
            {
                biggest = b;
                medium = a;
                smallest = c;
            }
            else if (b > c && c > a || a == b || c == a)
            {
                biggest = b;
                medium = c;
                smallest = a;
            }

            else if (c > b && a > b || a == b|| c == a)
            {
                biggest = c;
                medium = a;
                smallest = b;
            }

            else if (c > b && b > a || a == b || c == a)
            {
                biggest = c;
                medium = b;
                smallest = a;
            }

            Console.WriteLine(biggest);
            Console.WriteLine(medium);
            Console.WriteLine(smallest);
        }
    }
}
