using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Hospital
{
    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();

            CreateRooms();
        }

        public string Name { get; set; }
        public List<Room> Rooms { get; set; }




        private void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                this.Rooms.Add(new Room());
            }
        }



        public void AddPatient( Patient patient)
        {
            var currentRoom = this.Rooms.FirstOrDefault(r => !r.IsFull);

            currentRoom.Patients.Add(patient);       
        }

        public override string ToString()
        {
            StringBuilder departmentsInfo = new StringBuilder();
            foreach (var room in this.Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    departmentsInfo.AppendLine(patient.Name);
                }

            }

            return departmentsInfo.ToString().TrimEnd();
        }

    }
}
