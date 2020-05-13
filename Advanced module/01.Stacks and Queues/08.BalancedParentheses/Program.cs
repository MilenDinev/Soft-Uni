using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> openingBrackets = new Stack<char>();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            string allowedOpeningBrackets = "({[";

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (allowedOpeningBrackets.Contains(currentChar))
                {
                    openingBrackets.Push(currentChar);
                }
                else if ((openingBrackets.Count > 0) && ((openingBrackets.Peek() == '(' && currentChar == ')') || (openingBrackets.Peek() == '{' && currentChar == '}') || (openingBrackets.Peek() == '[' && currentChar == ']')))
                {
                    openingBrackets.Pop();
                }

                else
                {
                    Console.WriteLine("NO");

                    return;
                }
            }


            if (openingBrackets.Count > 0)
            {
                Console.WriteLine("NO");
                return;
            }


            Console.WriteLine("YES");

            Console.WriteLine(string.Join(" ", openingBrackets));
        }
    }
}
