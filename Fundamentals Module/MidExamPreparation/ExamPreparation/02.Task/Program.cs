﻿//02. Seize the Fire


/* 
 Seize the Fire
The group of adventurists have gone on their first task. Now they have to walk through fire - literally. They have to use all of the water they have left. Your task is to help them survive.
Create a program that calculates the water that is needed to put out a "fire cell", based on the given information about its "fire level" and how much it gets affected by water.
First, you will be given the level of fire inside the cell with the integer value of the cell, which represents the needed water to put out the fire.  They will be given in the following format:
"{typeOfFire} = {valueOfCell}#{typeOfFire} = {valueOfCell}#{typeOfFire} = {valueOfCell}……"
Afterwards you will receive the amount of water you have for putting out the fires. There is a range of fire for each of the fire types, and if a cell’s value is below or exceeds it, it is invalid and you don’t need to put it out.
Type of Fire	Range
High	81 - 125
Medium	51 - 80
Low	1 - 50
If a cell is valid, you have to put it out by reducing the water with its value. Putting out fire also takes effort and you need to calculate it. Its value is equal to 25% of the cell’s value. In the end you will have to print the total effort. Keep putting out cells until you run out of water. If you don’t have enough water to put out a given cell – skip it and try the next one. In the end, print the cells you have put out in the following format:
"Cells:
 - {cell1}
 - {cell2}
 - {cell3}
……
 - {cellN}"
"Effort: {effort}"
In the end, print the total fire you have put out from all of the cells in the following format: "Total Fire: {totalFire}"
Input / Constraints
•	On the 1st line you are going to receive the fires with their cells in the format described above – integer numbers in the range [1…500]
•	On the 2nd line, you are going to be given the water – an integer number in the range [0….100000]
Output
•	Print the cells, which you have put out in the following format:
"Cells:
 - {cell}
 - {cell2}
 - {cell3}
 - {cell5}
……
 - {cellN}"
•	Print the effort, rounded 2 digits after the decimal separator in the following format:
"Effort: {effort}"
•	Print the total fire put out
"Total Fire: {totalFire}"
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fire = Console.ReadLine().Split("#").ToArray();

            List<int> firesCompleted = new List<int>();

            int totalWater = int.Parse(Console.ReadLine());
            double effort = 0;

            for (int i = 0; i < fire.Length; i++)
            {
                string[] fireArgs = fire[i].Split(" = ");

                string fireType = fireArgs[0];
                int fireValue = int.Parse(fireArgs[1]);


                bool isValidCell = IsValidCell(fireType, fireValue);


                if (isValidCell && totalWater - fireValue >= 0)
                {
                    effort += fireValue * 0.25;
                    totalWater -= fireValue;
                    firesCompleted.Add(fireValue);
                }
            }


            Console.WriteLine("Cells:");
            foreach (var cell in firesCompleted)
            {
                Console.WriteLine($" - {cell}" );
            }
            
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {firesCompleted.Sum()}");
        }
        private static bool IsValidCell(string fireType, int fireValue)
        {
            if (fireType == "High")
            {
                return fireValue >= 81 && fireValue <= 125;
            }

            if (fireType == "Medium")
            {
                return fireValue >= 51 && fireValue <= 80;
            }

            if (fireType == "Low")
            {
                return fireValue >= 1 && fireValue <= 50;
            }

            return false;
        }
    }

}