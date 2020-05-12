using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> specialnNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();


            for (int i = 0; i < numbers.Count; i++)
            {
                if (specialnNumbers[0] == numbers[i])
                {

                    for (int j = 0; j <= specialnNumbers[1]; j++)
                    {

                        if (i - j < 0)
                        {

                            break;

                        }

                        else
                        {
                            numbers[i - j] = 0;

                        }

                    }

                    for (int j = 0; j <= specialnNumbers[1]; j++)
                    {

                        if (i + j > numbers.Count - 1)
                        {
                            break;
                        }
                        else
                        {
                            numbers[i + j] = 0;
                        }


                    }

                    numbers[i] = 0;
                }
            }

            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine(sum);
        }
    }
}
