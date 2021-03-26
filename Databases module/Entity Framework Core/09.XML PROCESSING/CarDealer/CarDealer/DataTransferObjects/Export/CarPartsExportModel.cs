

namespace CarDealer.DataTransferObjects.Export
{
    using System.Xml.Serialization;

    [XmlType("part")]
    public class CarPartsExportModel
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
