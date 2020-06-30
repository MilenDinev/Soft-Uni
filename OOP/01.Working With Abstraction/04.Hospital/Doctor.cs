using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Hospital
{
    public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;           
        }

        public string FullName => this.FirstName + " " + this.LastName;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Patient> Patients { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var patient in this.Patients.OrderBy(p => p.Name))
            {
                sb.AppendLine(patient.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
