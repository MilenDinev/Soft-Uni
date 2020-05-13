using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> symbolsCounter = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!symbolsCounter.ContainsKey(text[i]))
                {
                    symbolsCounter.Add(text[i], 0);
                }
                symbolsCounter[text[i]]++;
            }

            foreach (var symbol in symbolsCounter.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
