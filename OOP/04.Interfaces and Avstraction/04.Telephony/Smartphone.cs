using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _04.Telephony
{
    public class Smartphone : IPhone, IBrowser
    {
        public Smartphone(string model)
        {
            this.Model = model;
        }

        public string Model { get; set; }


        public string Browsing(string url)
        {
            if (url.Any(char.IsDigit))
            {
                return "Invalid URL!";
            }
            return $"Browsing: {url}!";
        }

        public string Calling(string phoneNumber)
        {
            if (phoneNumber.Any(char.IsLetter))
            {
                return "Invalid number!";
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
