using System;

namespace _05.DateModifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DateModifier dates = new DateModifier();
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            Console.WriteLine(dates.DateCalculator(firstDate, secondDate));
        }
    }
}
