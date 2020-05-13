using System;
using System.Collections.Generic;

namespace _06.Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsArr = Console.ReadLine().Split(", ");

            string input = Console.ReadLine();

            Queue<string> songs = new Queue<string>(songsArr);


            while (songs.Count > 0)
            {
                if (input == "Play")
                {
                    songs.Dequeue();
                }
                else if (input == "Show")
                {
                    Console.WriteLine($"{string.Join(", ", songs)}");
                }
                else if(input.Contains("Add"))
                {
                    string songToAdd = input.Substring(input.IndexOf(" "), input.Length - 3).Trim();
                    if (!songs.Contains(songToAdd))
                    {
                        songs.Enqueue(songToAdd);
                    }

                    else
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    

                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"No more songs!");
        }
    }
}
