namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("SoldProducts")]
    public class SoldProductCountExportModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public SoldProductExportModel[] SoldProducts { get; set; }

    }
}
