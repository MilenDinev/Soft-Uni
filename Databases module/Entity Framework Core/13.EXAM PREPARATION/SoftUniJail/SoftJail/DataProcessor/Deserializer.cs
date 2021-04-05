namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using SoftJail.DataProcessor.XMLHelper;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var departments = new List<Department>();

            var departmentsCellsDto = JsonConvert.DeserializeObject<IEnumerable<DepartmentImportModel>>(jsonString);

            foreach (var departmentCell in departmentsCellsDto)
            {
                if (!IsValid(departmentCell) || !departmentCell.Cells.All(x => IsValid(x)) || !departmentCell.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentCell.Name,
                    Cells = departmentCell.Cells.Select(c => new Cell
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow
                    }).ToList()
                };

                departments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count()} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var prisoners = new List<Prisoner>();

            var prisonersDto = JsonConvert.DeserializeObject<IEnumerable<PrisonerImportModel>>(jsonString);

            foreach (var currnetPrisoner in prisonersDto)
            {
                if (!IsValid(currnetPrisoner) || !(currnetPrisoner.Mails.All(x => IsValid(x))))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var incarcerationDate = DateTime.ParseExact(currnetPrisoner.IncarcerationDate,"dd/MM/yyyy", CultureInfo.InvariantCulture);
                var isValidReleaseDate = DateTime.TryParseExact(currnetPrisoner.ReleaseDate,"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                var prisioner = new Prisoner
                {
                    FullName = currnetPrisoner.FullName,
                    Nickname = currnetPrisoner.Nickname,
                    Age = currnetPrisoner.Age,
                    CellId = currnetPrisoner.CellId,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = currnetPrisoner.Bail,
                    Mails = currnetPrisoner.Mails.Select(m => new Mail
                    {
                        Address = m.Address,
                        Description = m.Description,
                        Sender = m.Sender

                    }).ToList()
                };

                prisoners.Add(prisioner);

                sb.AppendLine($"Imported {prisioner.FullName} {prisioner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            var officers = new List<Officer>();

            var officersDto = XmlConverter.Deserializer<OfficerPrisonerImportModel>(xmlString, "Officers");

            foreach (var currentOfficer in officersDto)
            {
                if (!IsValid(currentOfficer) || !currentOfficer.Prisoners.All(x => IsValid(x)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = currentOfficer.Name,
                    Salary = currentOfficer.Money,
                    Position = Enum.Parse<Position>(currentOfficer.Position),
                    Weapon = Enum.Parse<Weapon>(currentOfficer.Weapon),
                    DepartmentId = currentOfficer.DepartmentId,
                    OfficerPrisoners = currentOfficer.Prisoners.Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id
                    }).ToList()
                };

                officers.Add(officer);

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}
