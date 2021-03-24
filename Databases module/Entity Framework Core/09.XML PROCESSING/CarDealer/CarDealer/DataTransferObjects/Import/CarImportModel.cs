namespace CarDealer.DataTransferObjects.Import
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Car")]
   public class CarImportModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("make")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public ICollection<CarPartsImportModel> PartsIds { get; set; }
    }
}
