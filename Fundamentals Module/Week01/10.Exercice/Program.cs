using System;

namespace _10.Exercice
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesLost = int.Parse(Console.ReadLine());

            float headsetPrice = float.Parse(Console.ReadLine());
            float mousePrice = float.Parse(Console.ReadLine());
            float keyboardPrice = float.Parse(Console.ReadLine());
            float displayPrice = float.Parse(Console.ReadLine());

            int trshHeadset = gamesLost / 2;
            int trshMouse = gamesLost / 3;
            int trshkeyboard = gamesLost / 6;
            int trshDisplay = gamesLost / 12;

            float headsetExpenses = trshHeadset * headsetPrice;

            float mouseExpenses = trshMouse * mousePrice;

            float keyboardExpenses = trshkeyboard * keyboardPrice;

            float displayExpences = trshDisplay* displayPrice;

            float expenses = headsetExpenses + mouseExpenses + keyboardExpenses + displayExpences;

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
