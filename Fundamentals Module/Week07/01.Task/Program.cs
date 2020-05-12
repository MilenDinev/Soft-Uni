//01.	Count Chars in a String 

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            char[] characters = new char[words.Length];

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = words[i];
            }

            var charDict = new Dictionary<char, int>();


            foreach (var character in characters)
            {
                if (!charDict.ContainsKey(character) && character != ' ' )
                {
                    charDict[character] = 1;
                }
                else if (character != ' ')
                {
                    charDict[character]++;
                }

            }

            foreach (var character in charDict)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
