namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlRoot("Users")]
    public class UserFinalExportModel
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserSoldProductExportModel[] Users { get; set; }
    }
}