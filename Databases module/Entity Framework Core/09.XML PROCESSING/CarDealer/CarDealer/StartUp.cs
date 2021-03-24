using CarDealer.Data;
using CarDealer.DataTransferObjects.Import;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var suppliersXml = File.ReadAllText("./Datasets/suppliers.xml");
            var suppliersResult = ImportSuppliers(context, suppliersXml);

            var partsXml = File.ReadAllText("./Datasets/parts.xml");
            var partsResult = ImportParts(context, partsXml);

            Console.WriteLine(suppliersResult);
            Console.WriteLine(partsResult);
        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierImportModel[]), new XmlRootAttribute("Suppliers"));
            var textRead = new StringReader(inputXml);

            var suppliersDto = xmlSerializer.Deserialize(textRead) as SupplierImportModel[];

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            });

            context.Suppliers.AddRange(suppliers);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsDto = XmlConverter.Deserializer<PartImportModel>(inputXml, "Parts");

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partsDto
                .Where(p => supplierIds.Contains(p.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            var result = context.SaveChanges();

            return $"Successfully imported {result}";
        }
    }
}