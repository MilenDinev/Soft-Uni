using System;

namespace _07.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            float sum = 0.0f;
            float change = 0.0f;
            float price = 0.0f;
            while (input!= "Start")
            {
                float coins = float.Parse(input);

                if (coins == 0.1f || coins == 0.2f || coins == 0.5f || coins == 1.0f || coins == 2.0f)
                {
                    sum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }


                input = Console.ReadLine();
            }

            bool invalidProduct = true;
            bool noMoney = true;


            if (input == "Start")
            {
                while (input != "End")
                {

                    input = Console.ReadLine();
                    if (sum <= 0.0f)
                    {
                        noMoney = true;
                    }

                    if (sum >= 0.0f)
                    {
                        change = sum;
                        noMoney = false;


                        switch (input)
                        {
                            case "Nuts":
                                price = 2.0f;
                                invalidProduct = false;
                                break;
                            case "Water":
                                price = 0.7f;
                                invalidProduct = false;
                                break;
                            case "Crisps":
                                price = 1.5f;
                                invalidProduct = false;
                                break;
                            case "Soda":
                                price = 0.8f;
                                invalidProduct = false;
                                break;
                            case "Coke":
                                price = 1.0f;
                                invalidProduct = false;
                                break;

                            default:
                                invalidProduct = true;
                                break;
                        }

                        if (sum > 0.0f)
                        {
                            sum -= price;
                        }

                       
                    }


                    if (noMoney && !invalidProduct && input !="End")
                    {

                        Console.WriteLine("Sorry, not enough money");

                    }

                    if (!invalidProduct && !noMoney  && input !="End")
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                    }

                    if (invalidProduct && input !="End")
                    {
                        Console.WriteLine("Invalid product");
                    }


                }
                Console.WriteLine($"Change: {change:f2}");
            }
        }
    }
}
