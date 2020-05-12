using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            float money = float.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            float gamePrice = 0.0f;

            float totalSpent = 0.0f;
            bool outOfMoney = false;
            bool toExpensive = false;
            bool notFound = false;
            while (command != "Game Time" && !outOfMoney)
            {
                float temp = money;

                switch (command)
                {
                    case "OutFall 4":
                        gamePrice = 39.99f;
                        break;
                    case "CS: OG":
                        gamePrice = 15.99f;
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99f;
                        break;
                    case "Honored 2":
                        gamePrice = 59.99f;
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99f;
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99f;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        notFound = true;
                        break;
                }

                money -= gamePrice;


                if (money == 0.0f)
                {
                    outOfMoney = true;
                    Console.WriteLine($"Bought {command}");
                    Console.WriteLine("Out of money!");
                }


                

                if (money < 0.0f)
                {
                    Console.WriteLine("Too Expensive");
                    money = temp;
                    toExpensive = true;
                }


                
                if (money > 0.0f && toExpensive == false && notFound == false)
                {
                    Console.WriteLine($"Bought {command}");
                    totalSpent += gamePrice;
                }

                notFound = false;

                command = Console.ReadLine();

  
                

                if (command == "Game Time" && !outOfMoney)
                {
                    temp = money;
                    Console.WriteLine($"Total spent: ${totalSpent}. Remaining: ${temp:f2}");
                }
            }

        }
    }
}
