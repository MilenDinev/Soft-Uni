using System;
using System.Runtime.CompilerServices;

namespace _01.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ");

            for (int i = 0; i < userNames.Length; i++)
            {
                string username = userNames[i];
                bool isValid = true;

                for (int j = 0; j < username.Length; j++)
                {
                    if (!char.IsLetterOrDigit(username[j]) && username[j] != '_' && username[j] != '-' || (username.Length < 3 || username.Length > 16))
                    {
                        isValid = false;  
                    }
                }

                if (isValid)
                {
                    Console.WriteLine(username);
                }
            }
        }
    }
}
