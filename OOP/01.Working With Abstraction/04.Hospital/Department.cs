namespace _04.Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }

        public string Name { get; private set; }

        public List<Room> Rooms { get; private set; }

         public void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                this.Rooms.Add(new Room());
            }
        }

        public void AddPatient(Patient patient)
        {
            Room currentRoom = this.Rooms.FirstOrDefault(x => !x.IsFull);

            if (currentRoom != null)
            {
                currentRoom.Patients.Add(patient);
            }
        }
    }
}
