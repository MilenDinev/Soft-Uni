using System;

namespace _02.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split();
            string[] secondArr = Console.ReadLine().Split();

            string sameWords = string.Empty;

            for (int i = 0; i < secondArr.Length; i++)
            {

                for (int j = 0; j < firstArr.Length; j++)
                {
                    if (secondArr[i] == firstArr[j])
                    {
                        sameWords += secondArr[i] + " ";
                    }
                }

            }

            Console.WriteLine(sameWords);

        }
    }
}
