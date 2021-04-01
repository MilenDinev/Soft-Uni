namespace CarDealer.DataTransferObjects.Export
{
    using System.Xml.Serialization;

    [XmlType("suplier")]
   public class SupplierExportModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("parts-count")]
        public int PartsCount { get; set; }
    }
}
