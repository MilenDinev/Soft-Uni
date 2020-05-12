using System;

namespace _10.Task
{
    class Program
    {

        static void TopNumber(int n)
        {
            bool isItOdd = false;
            for (int i = 1; i <= n; i++)
            {
                isItOdd = false;
                int tempNumber = i;
                int currentDigitsSum = 0;
                while (tempNumber !=0)
                {

                    int currentDigit = tempNumber % 10;

                    currentDigitsSum += currentDigit;
                    tempNumber /= 10;

                    if (currentDigit % 2 == 1)
                    {
                        isItOdd = true;
                    }

                    
                }

                if (isItOdd && currentDigitsSum % 8 == 0)
                {
                    Console.WriteLine(i);
                }
                

            }
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            TopNumber(n);
        }
    }
}
