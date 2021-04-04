namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Xml;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.DataProcessor.XmlHelper;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .ToList()
                .Where(x => x.Tasks.Any())
                .Select(x => new ProjectExportModel
                {
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate.HasValue ? "Yes" : "No",
                    Tasks = x.Tasks.Select(x => new TaskExportModel
                    {
                        Name = x.Name,
                        Label = x.LabelType.ToString()
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()

                })
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.ProjectName)
                .ToList();

            var result = XmlConverter.Serialize(projects, "Projects");
            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToList()
                .Where(x => x.EmployeesTasks.Any(x => x.Task.OpenDate >= date))
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .ToList()
                    .Select(et => et.Task)
                    .Where(t => t.OpenDate >= date)
                    .OrderByDescending(t => t.DueDate)
                    .ThenBy(t => t.Name)
                    .Select(x => new
                    {
                        TaskName = x.Name,
                        OpenDate = x.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = x.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = x.LabelType.ToString(),
                        ExecutionType = x.ExecutionType.ToString()
                    })
                })
                .OrderByDescending(x => x.Tasks.Count())
                .ThenBy(x => x.Username)
                .Take(10);

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return result;
        }
    }
}

//                    Username = x.Username,
//                    Tasks = x.EmployeesTasks
//                    .Select(et => et.Task)
//                    .Where(t => t.OpenDate >= date)
//                    .OrderByDescending(t => t.DueDate)
//                    .ThenBy(t => t.Name)
//                    .Select(x => new
//                    {
//                        TaskName = x.Name,
//                        OpenDate = x.OpenDate.ToString("d", CultureInfo.InvariantCulture),
//                        DueDate = x.DueDate.ToString("d", CultureInfo.InvariantCulture),
//                        LabelType = x.LabelType,
//                        ExecutionType = x.ExecutionType
//                    })
//                    .ToList()