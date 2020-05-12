using System;

namespace _05.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Empty;
            int counter = 0;

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }




            string passwordIn = Console.ReadLine();




            while (passwordIn != password && counter < 3)
            {
                counter++;
                Console.WriteLine("Incorrect password. Try again.");

                passwordIn = Console.ReadLine();

                if (counter == 3)
                {
                    Console.WriteLine($"User {username} blocked!");
                }
            }



            if (counter < 3)
            {
                Console.WriteLine($"User {username} logged in.");
            }
            
        }
    }
}
