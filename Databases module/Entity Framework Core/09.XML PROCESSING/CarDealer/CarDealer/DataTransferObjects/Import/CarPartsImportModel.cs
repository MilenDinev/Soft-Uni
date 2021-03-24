namespace CarDealer.DataTransferObjects.Import
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class CarPartsImportModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
