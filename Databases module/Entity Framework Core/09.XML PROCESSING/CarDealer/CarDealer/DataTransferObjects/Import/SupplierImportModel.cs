namespace CarDealer.DataTransferObjects.Import
{
    using System.Xml.Serialization;

    [XmlType("Supplier")]
   public class SupplierImportModel
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
