using System;

namespace _04.Task
{
    class Program
    {
        static bool PasswordLenght(string password)
        {
            bool passwordLenght = false;
            if (password.Length >= 6 && password.Length <= 10)
            {
                passwordLenght = true;
            }

            return passwordLenght;
            
        }

        static bool PasswordLettersAndDigits(string password)
        {


            bool includeLettersAndDigits = true;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] < 48 || password[i] > 122)
                {
                    includeLettersAndDigits = false;
                    break;
                }
            }

            return includeLettersAndDigits;
        }

        static bool PasswordMinDigits(string password)
        {
            bool passwordMinDigits = false;
            int counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    counter++;
                }


            }

            if (counter >= 2 )
            {
                passwordMinDigits = true;
            }
            return passwordMinDigits;
        }
        static void PaswordValidator(string password)
        {
            

            if (PasswordLenght(password) == true && PasswordLettersAndDigits(password) == true && PasswordMinDigits(password) == true)
            {
                Console.WriteLine("Password is valid");
            }
            if (PasswordLenght(password) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (PasswordLettersAndDigits(password) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (PasswordMinDigits(password) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            PaswordValidator(password);
        }
    }
}
