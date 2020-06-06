
namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;


        public string Make
        {
            get
            {
                return this.make;
            }

            set
            {
                make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                model = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                year = value;
            }
        }

    }
}
