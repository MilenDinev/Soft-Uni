namespace CarDealer.DataTransferObjects.Import
{
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class CarPartsImportModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
