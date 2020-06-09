using System;

namespace _05.DateModifier
{
   public class DateModifier
    {
        private string firstDate;
        private string secondDate;

        public string FirstDate
        {
            get
            {
                return this.firstDate;
            }

            set
            {
                this.firstDate = value;
            }
        }

        public string SecondDate
        {
            get
            {
                return this.secondDate;
            }

            set
            {
                this.secondDate = value;
            }
        }
        public double DateCalculator(string firstDate, string secondDate)
        {
            double result = (DateTime.Parse(firstDate) - DateTime.Parse(secondDate)).TotalDays;
            return Math.Abs(result);
        }
    }
}
