﻿namespace CarDealer.DataTransferObjects.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarWithListOfPartsExportModel
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
 
        [XmlArray("parts")]
        public CarPartsExportModel[] Parts { get; set; }
    }
}
