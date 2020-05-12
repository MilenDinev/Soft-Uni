using System;
using System.Linq;
using System.Text;

namespace _05.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            StringBuilder numberBuilder = new StringBuilder();


            int onMind = 0;

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int lastDigit = int.Parse(bigNumber[i].ToString());

                int result = lastDigit * multiplier + onMind;

                onMind = result / 10;

                numberBuilder.Append(result % 10);
            }


            if (onMind != 0)
            {
                numberBuilder.Append(onMind);
            }

            string resultNumber = string.Join("", numberBuilder.
                ToString().
                Reverse()).
                TrimStart('0');


            if (resultNumber == string.Empty)
            {
                Console.WriteLine(0);
            }

            else
            {
                Console.WriteLine(resultNumber);
            }

        }
    }
}
