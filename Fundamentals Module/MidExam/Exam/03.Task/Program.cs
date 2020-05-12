using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            string[] commandArgs = command.Split();

            while (commandArgs[0] != "Print")
            {



                if (commandArgs[0] == "Add")
                {
                    if (contacts.Contains(commandArgs[1]) && int.Parse(commandArgs[2]) <= contacts.Count - 1 && int.Parse(commandArgs[2]) >= 0)
                    {
                        int index = int.Parse(commandArgs[2]);

                        contacts.Insert(index, commandArgs[1]);
                    }

                    else
                    {
                        contacts.Add(commandArgs[1]);
                    }

                }

                else if (commandArgs[0] == "Remove" && int.Parse(commandArgs[1]) <= contacts.Count - 1 && int.Parse(commandArgs[1]) >= 0)
                {
                    int index = int.Parse(commandArgs[1]);
                    contacts.RemoveAt(index);
                }

                

                else if (commandArgs[0] == "Export" && int.Parse(commandArgs[1]) >= 0)
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endCount = int.Parse(commandArgs[1]) + int.Parse(commandArgs[2]);

                    if (endCount < contacts.Count)
                    {
                        Console.WriteLine(String.Join(" ", contacts.GetRange(startIndex, int.Parse(commandArgs[2])))); 

                        //for (int i = startIndex; i < endCount; i++)
                        //{

                        //    if (i != endCount - 1)
                        //    {
                        //        Console.Write(contacts[i] + " ");
                        //    }
                        //    else 
                        //    {
                        //        Console.Write(contacts[i]);
                        //    }
                        //}

                        //Console.WriteLine();
                    }

                    else
                    {

                        for (int i = startIndex; i < contacts.Count; i++)
                        {
                            if (i != contacts.Count - 1)
                            {
                                Console.Write(contacts[i] + " ");
                            }
                            else 
                            {
                                Console.Write(contacts[i]);
                            }

                        }
                        Console.WriteLine();
                    }



                }

                command = Console.ReadLine();
                commandArgs = command.Split();
            }

            if (commandArgs[1] == "Normal")
            {
                Console.Write("Contacts: ");
                Console.WriteLine(String.Join(" ", contacts));
            }

            else if (commandArgs[1] == "Reversed")
            {
                contacts.Reverse();
                Console.Write("Contacts: ");
                Console.WriteLine(String.Join(" ", contacts));
            }



        }
    }
}
