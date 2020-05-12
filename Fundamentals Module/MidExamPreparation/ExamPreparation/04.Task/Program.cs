//01.Party Profit

/*       */

using System;

namespace _04.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            int totalDays = int.Parse(Console.ReadLine());

            int totalCoins = 0;


            for (int i = 1; i <= totalDays; i++)
            {
                if (i % 10 == 0)
                {
                    groupSize -= 2;
                }

                if (i % 15 == 0)
                {
                    groupSize += 5;
                }

                int foodCoins = groupSize * 2;
                int waterCoins = groupSize * 3;
                int monsterCoins = groupSize * 20;


                totalCoins += 50;
                totalCoins -= foodCoins;

                if (i % 3 == 0)
                {
                    totalCoins -= waterCoins;
                }

                if (i % 5 == 0)
                {
                    totalCoins += monsterCoins;

                    if (i % 3 == 0)
                    {
                        totalCoins -= groupSize * 2;
                    }
                }


            }

            Console.WriteLine($"{groupSize} companions received {totalCoins/ groupSize} coins each.");
        }
    }
}
