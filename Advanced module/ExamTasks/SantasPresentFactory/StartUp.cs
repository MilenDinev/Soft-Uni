namespace SantasPresentFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    class StartUp
    {
        static void Main()
        {
            Stack<int> materials = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> magicLevelValues = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> toys = new Dictionary<string, int>()
            {
             {"Doll", 0},
             {"Wooden train", 0},
             {"Teddy bear", 0},
             {"Bicycle", 0}
            };


            while (materials.Any() && magicLevelValues.Any())
            {
                int currentMaterial = materials.Peek();
                int currentMagicLevel = magicLevelValues.Peek();

                if (currentMaterial == 0 || currentMagicLevel == 0)
                {
                    if (currentMaterial == 0)
                    {
                        materials.Pop();
                    }
                    if (currentMagicLevel == 0)
                    {
                        magicLevelValues.Dequeue();
                    }
                    continue;
                }


                int sum = currentMaterial * currentMagicLevel;

                if (sum < 0)
                {
                    int currentSum = currentMaterial + currentMagicLevel;
                    materials.Pop();
                    magicLevelValues.Dequeue();
                    materials.Push(currentSum);
                    continue;
                }

                if ((sum != 150 && sum !=250 && sum != 300 && sum != 400) && sum > 0)
                {
                    magicLevelValues.Dequeue();
                    int increaseMats = materials.Pop() + 15;
                    materials.Push(increaseMats);

                    continue;
                }


                if (sum == 150)
                {
                    toys["Doll"]++;

                    materials.Pop();
                    magicLevelValues.Dequeue();
                    continue;
                }

                if (sum == 250)
                {
                    toys["Wooden train"]++;
                    materials.Pop();
                    magicLevelValues.Dequeue();
                    continue;
                }

                if (sum == 300)
                {
                    toys["Teddy bear"]++;
                    materials.Pop();
                    magicLevelValues.Dequeue();
                    continue;
                }

                if (sum == 400)
                {
                    toys["Bicycle"]++;
                    materials.Pop();
                    magicLevelValues.Dequeue();
                    continue;
                }

            }


            bool firstCouple = toys["Doll"] > 0 && toys["Wooden train"] > 0;
            bool secondCouple = toys["Teddy bear"] > 0 && toys["Bicycle"] > 0;

            if (firstCouple || secondCouple)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");


            }

            else if (!firstCouple && !secondCouple)
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }

            if (magicLevelValues.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicLevelValues)}");
            }

            foreach (var toy in toys.OrderBy(x=> x.Key).Where(x => x.Value > 0))
            {
                Console.WriteLine($"{toy.Key}: {toy.Value}");
            }
        }
    }
}
