namespace _04.Hospital
{
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public Hospital()
        {
            this.Doctors = new List<Doctor>();
            this.Departments = new List<Department>();
        }

        public List<Doctor> Doctors { get; set; }

        public List<Department> Departments { get; set;}
        
        public void AddDoctor (string firstName, string lastName)
        {
            if (!this.Doctors.Any(d => d.FirstName == firstName && d.LastName == lastName))
            {
                Doctor doctor = new Doctor(firstName, lastName);
                this.Doctors.Add(doctor);
            }
        }

        public void AddDeaprtment(string name)
        {
            if (!this.Departments.Any(de=> de.Name == name))
            {
                Department department = new Department(name);
                this.Departments.Add(department);
            }
        }

        public void AddPatient(string departmentName, string doctorName, string patientName)
        {
            Department currentDepartment = this.Departments.FirstOrDefault(de => de.Name == departmentName);
            Doctor currentDoctor = this.Doctors.FirstOrDefault(d => d.FullName == doctorName);
            Patient patient = new Patient(patientName);

            currentDepartment.AddPatient(patient);
            currentDoctor.Patients.Add(patient);
        }
    }
}
