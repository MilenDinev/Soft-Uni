namespace _04.Hospital
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Room
    {
        public Room()
        {
            this.Patients = new List<Patient>();
        }

        public List<Patient> Patients { get; set; }


        public bool IsFull => this.Patients.Count >= 3 ? true : false;

        
    }
}
