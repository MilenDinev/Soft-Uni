using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> sortedClothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < rotations; i++)
            {

                string[] colorAndClothes = Console.ReadLine().Split(" -> ");

                string currentColor = colorAndClothes[0];

                string[] clothes = colorAndClothes[1].Split(',');

                for (int j = 0; j < clothes.Length; j++)
                {

                    string currentCloth = clothes[j];

                    if (!sortedClothes.ContainsKey(currentColor))
                    {
                        sortedClothes.Add(currentColor, new Dictionary<string, int>());



                        if (!sortedClothes[currentColor].ContainsKey(currentCloth))
                        {
                            sortedClothes[currentColor].Add(currentCloth, 0);
                        }
                        sortedClothes[currentColor][currentCloth]++;


                    }

                    else if (!sortedClothes[currentColor].ContainsKey(currentCloth))
                    {
                        sortedClothes[currentColor].Add(currentCloth, 1);
                    }

                    else
                    {
                        sortedClothes[currentColor][currentCloth]++;
                    }



                }


            }


            string[] searching = Console.ReadLine().Split();
            string searchedColor = searching[0];
            string searchedCloth = searching[1];



            foreach (var color in sortedClothes)
            {

                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothes in color.Value)
                {
                    if (color.Key == searchedColor && clothes.Key == searchedCloth)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                    
                }
            }


        }
    }
}
