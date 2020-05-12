using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int totalAmount = 0;
            int consumation = 26;
            int days = 0;

            if (startingYield >= 100)
            {
                while (startingYield >= 100)
                {
                    totalAmount += startingYield;
                    days++;
                    startingYield -= 10;

                }

                Console.WriteLine(days);
                Console.WriteLine(totalAmount - (days * consumation) - 26);
            }
            else
            {
                Console.WriteLine(days);
                Console.WriteLine(totalAmount);
            }

        }
    }
}
