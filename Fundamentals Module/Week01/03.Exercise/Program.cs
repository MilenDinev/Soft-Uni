using System;

namespace _03.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            float price = 0.0f;
            float totalPrice = 0.0f;

            if (group < 0)
            {
                group = 0;
            }

            switch (groupType)
            {
                case "Students":
                    switch (day)
                    {
                        case "Friday":
                            price = 8.45f;
                            totalPrice = group * price;
                            break;
                        case "Saturday":
                            price = 9.80f;
                            totalPrice = group * price;
                            break;
                        case "Sunday":
                            price = 10.46f;
                            totalPrice = group * price;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Business":
                    switch (day)
                    {
                        case "Friday":
                            price = 10.90f;
                            totalPrice = group * price;
                            break;
                        case "Saturday":
                            price = 15.60f;
                            totalPrice = group * price;
                            break;
                        case "Sunday":
                            price = 16.00f;
                            totalPrice = group * price;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Regular":
                    switch (day)
                    {
                        case "Friday":
                            price = 15.00f;
                            totalPrice = group * price;
                            break;
                        case "Saturday":
                            price = 20.00f;
                            totalPrice = group * price;
                            break;
                        case "Sunday":
                            price = 22.50f;
                            totalPrice = group * price;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }



            if (group >= 30 && groupType == "Students")
            {
                totalPrice = totalPrice - (totalPrice * 0.15f);
            }

            else if (group >= 100 && groupType == "Business")
            {
                totalPrice = totalPrice - (price * 10);
            }


            else if ((group >= 10 && group <= 20) && groupType == "Regular") 
            {
                totalPrice = totalPrice - (totalPrice * 0.5f);
            }


            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
