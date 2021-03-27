namespace CarDealer.DataTransferObjects.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
   public class CarSaleExportModel
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
