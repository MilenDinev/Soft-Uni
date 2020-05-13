using System;

namespace _04.Telephony
{
    class Startup
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone("Iphone");

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                Console.WriteLine(smartphone.Calling(phoneNumbers[i]));
            }

            for (int i = 0; i < urls.Length; i++)
            {
                Console.WriteLine(smartphone.Browsing(urls[i]));
            }
        }
    }
}
