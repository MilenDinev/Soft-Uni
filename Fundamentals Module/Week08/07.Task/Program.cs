using System;

namespace _07.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] splitetInput = input.Split(">");

            string result = splitetInput[0];
            int remainingPower = 0;

            for (int i = 1; i < splitetInput.Length; i++)         
            {
                result += ">";

                string currentString = splitetInput[i];
                char digitSymbol = currentString[0];
                int power = int.Parse(digitSymbol.ToString()) + remainingPower ; 

                if (power > currentString.Length)
                {
                   remainingPower = power - currentString.Length;
                }
                else
                {
                    result += currentString.Substring(power);
                }
            }


            Console.WriteLine(result);
        }
    }
}
