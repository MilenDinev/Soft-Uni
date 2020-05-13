using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(clothesArr);
            int rackCapacity = int.Parse(Console.ReadLine());

            int temp = 0;
            int counter = 0;

            while (clothes.Count != 0)
            {
                
                    int currentClothes = clothes.Pop();
                    temp += currentClothes;
                    if (temp == rackCapacity && clothes.Count > 0)
                    {
                        temp = 0;
                        counter++;
                    }
                    else if (temp > rackCapacity)
                    {
                        counter++;
                        temp -= rackCapacity;
                    }

                    else if (clothes.Count == 0 && temp < rackCapacity && temp != 0)
                    {
                        counter++;
                    }
            }
            if (temp > 0)
            {
                counter++;
            }
            

            Console.WriteLine(counter);
        }
    }
}
