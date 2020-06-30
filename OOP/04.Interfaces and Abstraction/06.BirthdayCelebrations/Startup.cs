using System;
using System.Collections.Generic;

namespace _06.BirthdayCelebrations
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IBirthday> citizens = new List<IBirthday>();



            while (input != "End")
            {
                string[] inputArgs = input.Split();

                if (inputArgs[0] == "Citizen")
                {
                    string name = inputArgs[1];
                    int age = int.Parse(inputArgs[2]);
                    string id = inputArgs[3];
                    string birthday = inputArgs[4];

                    Human human = new Human(name, age, id, birthday);

                    citizens.Add(human);
                }
                else if (inputArgs[0] == "Pet")
                {
                    string name = inputArgs[1];
                    string birthday = inputArgs[2];

                    Pet pet = new Pet(name, birthday);

                    citizens.Add(pet);
                }
                input = Console.ReadLine();
            }

            string birthYear = Console.ReadLine();

            List<string> birthYears = new List<string>();

            foreach (var citizen in citizens)
            {
                string lastSymbols = citizen.Birthday.Substring(citizen.Birthday.Length - birthYear.Length, birthYear.Length);

                if (lastSymbols == birthYear)
                {
                    birthYears.Add(citizen.Birthday);
                }
            }


            foreach (var birthday in birthYears)
            {
                Console.WriteLine(birthday);
            }
        }
    }
}
