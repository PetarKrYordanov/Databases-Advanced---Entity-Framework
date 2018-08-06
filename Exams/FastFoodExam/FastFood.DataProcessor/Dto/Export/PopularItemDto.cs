using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Export
{
    [XmlRoot("MostPopularItem")]
    public class PopularItemDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("TotalMade")]
        public decimal TotalMade { get; set; }
        [XmlElement("TimesSold")]
        public int TimesSold { get; set; }
    }
}