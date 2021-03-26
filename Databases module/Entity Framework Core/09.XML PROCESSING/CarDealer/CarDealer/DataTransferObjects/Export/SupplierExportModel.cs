namespace CarDealer.DataTransferObjects.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("supplier")]
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
