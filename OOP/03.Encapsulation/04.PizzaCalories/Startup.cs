namespace _04.PizzaCalories
{
    using System;

    public class Startup
    {
        static void Main()
        {

            string[] pizzaInput = Console.ReadLine().Split();
            string pizzaName = pizzaInput[1];


            string[] doughInput = Console.ReadLine().Split();


            string flourType = doughInput[1];
            string backingTech = doughInput[2];
            double weight = double.Parse(doughInput[3]);

            string command = Console.ReadLine();

            try
            {
                Dough dough = new Dough(flourType, backingTech, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                while (command != "END")
                {
                    string[] toppingInput = command.Split();
                    string type = toppingInput[1];
                    double toppingWeight = double.Parse(toppingInput[2]);
                    Topping topping = new Topping(toppingWeight, type);
                    pizza.AddTopping(topping);
                    command = Console.ReadLine();
                }


                Console.WriteLine($"{pizzaName} - {pizza.GetCallories():f2} Calories.");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
