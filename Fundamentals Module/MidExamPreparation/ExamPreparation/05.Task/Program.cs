//02.Easter Gift

/*       */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gifts = Console.ReadLine().Split().ToList();


            string command = Console.ReadLine();

            while (command !="No Money")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "OutOfStock")
                {

                    while (gifts.Contains(commandArgs[1]))
                    {
                        int index = gifts.IndexOf(commandArgs[1]);
                        gifts[index] = "None";
                    }

                }



                if (commandArgs[0] == "Required" && int.Parse(commandArgs[2]) < gifts.Count)
                {

                    int index = int.Parse(commandArgs[2]);

                    gifts[index] = commandArgs[1];

                }


                if (commandArgs[0] == "JustInCase")
                {
                    gifts[gifts.Count - 1] = commandArgs[1];
                }



                command = Console.ReadLine();
            }

            for (int i = 0; i < gifts.Count; i++)
            {
                if (gifts[i] != "None")
                {
                    if (i != gifts.Count - 1)
                    {
                        Console.Write(gifts[i] + " ");
                    }
                    else
                    {
                        Console.Write(gifts[i]);
                    }
                }
                
            }
            Console.WriteLine();
           
        }
    }
}
