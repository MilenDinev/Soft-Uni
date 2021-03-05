using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstNum = 0;
            int secondNum = 1;

            for (int i = n; i > 0; i--)
            {
                Console.Write($"Index: {i}, SUM: ");
                int tempSum = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = tempSum;

                Console.Write($"{firstNum}");


                Console.WriteLine();
            }

            Console.WriteLine(firstNum);
        }
    }
}

//int n = int.Parse(Console.ReadLine());
//int startingNum = n;

//for (int i = n - 1; i > 1; i--)
//{
//    Console.Write($"Index: {i}, SUM: ");
//    startingNum *= i;

//    Console.Write($"{startingNum}");


//    Console.WriteLine();
//}

//Console.WriteLine(startingNum);
