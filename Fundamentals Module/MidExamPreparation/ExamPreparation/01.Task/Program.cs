// 01. The Hunting Games

/*
A group of friends have decided to participate in a game called "The Hunting Games". The first stage of the game is to gather some supplies. They have a list and your job is to help them follow it and make the needed calculations.
Write a program that calculates the needed provisions for a quest in the woods.
First you will receive the days of the adventure, the count of the players and the group’s energy. Afterwards, you will receive the following provisions per day for one person:
*	Water
*	Food
The group calculates how many supplies they’d need for the adventure and take that much water and food.
Every day they chop wood and lose a certain amount of energy. For each of the days, you are going to receive the energy loss from chopping wood. The program should end If the energy reaches 0 or less. 
Every second day they drink water, which boosts their energy with 5% of their current energy and at the same time drops their water supplies by 30% of their current water.
Every third day they eat, which reduces their food supplies by the following amount:
{currentFood} / {countOfPeople} and at the same time raises their group’s energy by 10%.
The chopping of wood, the drinking of water, and the eating happen in the order above.
If they have enough energy to finish the quest, print the following message:
"You are ready for the quest. You will be left with - {energyLevel} energy!"
If they run out of energy print the following message and the food and water they were left with before they ran out of energy: 
"You will run out of energy. You will be left with {food} food and {water} water."
Input / Constraints
•	On the 1st line, you are going to receive a number N - the days of the adventure – an integer in the range [1…100]
•	On the 2nd line – the count of players – an integer in the range [0 – 1000]
•	On the 3rd line - the group’s energy – a real number in the range [1 - 50000]
•	On the 4th line – water per day for one person – a real number [0.00 – 1000.00]
•	On the 5th line – food per day for one person – a real number [0.00 – 1000.00]
•	On the next N lines – one for each of the days – the amount of energy loss– a real number in the range [0.00 - 1000]
•	You will always have enough food and water.
Output
•	"You are ready for the quest. You will be left with - {energyLevel} energy!" – 
if they have enough energy
"You will run out of energy. You will be left with {food} food and {water} water."
•	All of the real numbers should be formatted to the second digit after the decimal separator
*/

using System;

namespace _01.Task
{
    class Program
    {
        static void Main(string[] args)
        {

            int daysOfTheAdventure = int.Parse(Console.ReadLine());
            int totalPlayers = int.Parse(Console.ReadLine());
            double totalGroupEnergy = double.Parse(Console.ReadLine());
            double waterPerPerson = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());

            double totalWater = daysOfTheAdventure * waterPerPerson * totalPlayers;
            double totalFood = daysOfTheAdventure * foodPerPerson * totalPlayers;

            bool isBreaked = false;

            for (int i = 1; i <= daysOfTheAdventure; i++)
            {
                double woodEnergy = double.Parse(Console.ReadLine());

                if (totalGroupEnergy - woodEnergy <= 0)
                {
                    isBreaked = true;
                    break;                   
                }

                totalGroupEnergy -= woodEnergy;

                if (i % 2 == 0)
                {
                    totalGroupEnergy *= 1.05;
                    totalWater *= 0.7;

                }

                if (i % 3 == 0)
                {
                    totalFood -= totalFood / totalPlayers;
                    totalGroupEnergy *= 1.10;

                }

            }

            if (isBreaked)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }

            else
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {totalGroupEnergy:f2} energy!");
            }



        }

    }
}



//    int days = int.Parse(Console.ReadLine());
//    int playersCount = int.Parse(Console.ReadLine());
//    double groupEnergy = double.Parse(Console.ReadLine());
//    double waterPerPerson = double.Parse(Console.ReadLine());
//    double foodPerPerson = double.Parse(Console.ReadLine());
//    double totalWater = days * playersCount * waterPerPerson;
//    double totalFood = days * playersCount * foodPerPerson;

//    bool isBraked = false;

//    for (int i = 1; i <= days; i++)
//    {
//        double woodEnergy = double.Parse(Console.ReadLine());

//        if (groupEnergy - woodEnergy <= 0)
//        {
//            isBraked = true;
//            break;
//        }

//        groupEnergy -= woodEnergy;

//        if (i % 2 == 0)
//        {
//            groupEnergy *= 1.05;
//            totalWater *= 0.7;
//        }
//        if (i % 3 == 0)
//        {
//            totalFood -= totalFood / playersCount;
//            groupEnergy *= 1.10;
//        }



//    }
//    if (isBraked)
//    {
//        Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
//    }

//    else
//    {
//        Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
//    }

//}