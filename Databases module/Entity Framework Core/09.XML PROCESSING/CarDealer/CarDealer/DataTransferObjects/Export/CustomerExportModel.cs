namespace CarDealer.DataTransferObjects.Export
{
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class CustomerExportModel
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; }
        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }
        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }

    }
}
