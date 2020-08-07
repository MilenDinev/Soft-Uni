namespace _04.Telephony
{
    using System.Linq;
    public class Smartphone : ICaller, IBrowser
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
