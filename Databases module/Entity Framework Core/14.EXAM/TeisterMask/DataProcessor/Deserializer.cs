namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.DataProcessor.XmlHelper;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {

            var projectsDto = XmlConverter.Deserializer<ProjectImportModel>(xmlString, "Projects");
            var projects = new List<Project>();
            StringBuilder sb = new StringBuilder();

            foreach (var currentProject in projectsDto)
            {
                var isValidProjectOpenDate = DateTime.TryParseExact(currentProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectOpenDate);
                var isValidProjectDueDate = DateTime.TryParseExact(currentProject.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectDueDate);
                if (!IsValid(currentProject) || !isValidProjectOpenDate)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var tasks = new List<Task>();

                foreach (var currentTask in currentProject.Tasks)
                {
                    var isValidTaskOpenDate = DateTime.TryParseExact(currentTask.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);
                    var isValidTaskDueDate = DateTime.TryParseExact(currentTask.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);



                    int compareOpenDates = DateTime.Compare(taskOpenDate, projectOpenDate);

                    int compareDueDates = DateTime.Compare(taskDueDate, projectDueDate);

                    if (!IsValid(currentTask) || !isValidTaskOpenDate || !isValidTaskDueDate || compareOpenDates < 0 || (isValidProjectDueDate && compareDueDates > 0))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var task = new Task
                    {
                        Name = currentTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)(currentTask.ExecutionType),
                        LabelType = (LabelType)(currentTask.LabelType),
                    };

                    tasks.Add(task);
                }

                var project = new Project
                {
                    Name = currentProject.Name,
                    OpenDate = projectOpenDate,
                    DueDate = isValidProjectDueDate ? projectDueDate : (DateTime?)null,

                    Tasks = tasks
                };

                projects.Add(project);

                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var employeesDto = JsonConvert.DeserializeObject<IEnumerable<EmployeeImportModel>>(jsonString);


            foreach (var currentEmployee in employeesDto)
            {
                if (!IsValid(currentEmployee))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var employee = new Employee
                {
                    Username = currentEmployee.Username,
                    Email = currentEmployee.Email,
                    Phone = currentEmployee.Phone
                };

                foreach (var currentTask in currentEmployee.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(x => x.Id == currentTask);

                    if (task == null)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask { Task = task });

                }

                context.Employees.Add(employee);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count()} tasks.");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }




        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
    
}