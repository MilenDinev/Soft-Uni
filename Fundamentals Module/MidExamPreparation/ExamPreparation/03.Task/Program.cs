//03.The Final Quest

/*
After walking through fire, the group has reached the final step of the quest. They have received a list with instructions that will help them resolve the last riddle that will lead them to the truth about the Hunting Games.
Create a program that follows given instructions. You will receive a collection of words on a single line, split by a single space. They are not what they are supposed to be, so you have to follow the instructions in order to find the real message. You will be receiving commands. Here are the possible ones:
-	Delete {index} – removes the word after the given index if it is valid.
-	Swap {word1} {word2} – find the given words in the collections if they exist and swap their places.
-	Put {word} {index} – add a word at the previous place {index} before the 
given one, if it is valid. Note: putting at the last index simply appends the word to the end of the list.
-	Sort – you must sort the words in descending order.
-	Replace {word1} {word2} – find the second word {word2} in the collection (if it exists) and replace it with the first word – {word1}.
Follow them until you receive the "Stop" command. After you have successfully followed the instructions, you must print the words on a single line, split by a space.
Input / Constraints
•	On the 1st line, you are going to receive the collection of words, split by a single space – strings
•	On the next lines, you are going to receive commands, until you receive the "Stop" command
Output
•	Print the words you have gathered on a single line, split by a single space
 */


using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();


            while (input != "Stop")
            {
                string[] commandArgs = input.Split();

                string command = commandArgs[0];


                if (command == "Delete")
                {
                    int index = int.Parse(commandArgs[1]) + 1;

                    if (index >= 0 && index < words.Count)
                    {
                        words.RemoveAt(index);
                    }
                }

                else if (command =="Swap")
                {
                    string firstWord = commandArgs[1];
                    string secondWord = commandArgs[2];

                    if (words.Contains(firstWord) && words.Contains(secondWord))
                    {
                        int firstWordIndex = words.IndexOf(firstWord);
                        int secondWordIndex = words.IndexOf(secondWord);

                        words[secondWordIndex] = firstWord;
                        words[firstWordIndex] = secondWord;
                    }
                }


                else if (command == "Put")
                {
                    string word = commandArgs[1];

                    int index = int.Parse(commandArgs[2]) - 1;

                    if (index >= 0 && index <= words.Count)
                    {
                        words.Insert(index, word);
                    }
                }

                else if (command == "Sort")
                {
                    words.Sort();
                    words.Reverse();
                }

                else if (command == "Replace")
                {
                    string firstWord = commandArgs[1];
                    string secondWord = commandArgs[2];

                    if (words.Contains(secondWord))
                    {
                        int secondWordIndex = words.IndexOf(secondWord);
                        words[secondWordIndex] = firstWord;
                    }
                }



                input = Console.ReadLine();


            }

            Console.WriteLine(String.Join(" ", words));
        }
    }
}


/*
           List<string> words = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();

            while (input !="Stop")
            {
                string[] commandArgs = input.Split();

                string command = commandArgs[0];


                switch (command)
                {
                    case "Delete":
                        int index = int.Parse(commandArgs[1]) + 1;

                        if (index >= 0 && index < words.Count)
                        {
                            words.RemoveAt(index);
                        }

                        break;

                    case "Swap":

                        string firstWord = commandArgs[1];
                        string secondWord = commandArgs[2];

                        if (words.Contains(firstWord) && words.Contains(secondWord))
                        {
                            int firstWordIndex = words.IndexOf(firstWord);
                            int secondWordIndex = words.IndexOf(secondWord);

                            words[secondWordIndex] = firstWord;
                            words[firstWordIndex] = secondWord;
                        }




                        break;

                    case "Put":

                        string word = commandArgs[1];

                        index = int.Parse(commandArgs[2]) - 1;

                        if (index >= 0 && index < words.Count)
                        {
                            words.Insert(index, word);
                        }



                        break;



                    case "Sort":

                        words.Sort();
                        words.Reverse();

                        break;

                    case "Replace":
                        firstWord = commandArgs[1];
                        secondWord = commandArgs[2];

                        if (words.Contains(secondWord))
                        {
                            int secondWordIndex = words.IndexOf(secondWord);
                            words[secondWordIndex] = firstWord;
                        }

                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();


            }

            Console.WriteLine(String.Join(" ", words));
     */
