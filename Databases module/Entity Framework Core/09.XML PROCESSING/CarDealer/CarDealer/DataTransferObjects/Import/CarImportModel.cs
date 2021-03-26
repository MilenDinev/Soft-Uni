namespace CarDealer.DataTransferObjects.Import
{
    using System.Xml.Serialization;

    [XmlType("Car")]
   public class CarImportModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public CarPartsImportModel[] PartsIds { get; set; }
    }
}
