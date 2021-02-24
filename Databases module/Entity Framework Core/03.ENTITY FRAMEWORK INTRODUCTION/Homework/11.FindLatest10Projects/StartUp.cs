namespace SoftUni
{
    using SoftUni.Data;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            System.Console.WriteLine(GetLatestProjects(db));
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var projects = context.Projects
                .Select(x => new 
                { 
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .ToList();

            foreach (var project in projects.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");

            }

            return sb.ToString().Trim();
        }
    }
}
