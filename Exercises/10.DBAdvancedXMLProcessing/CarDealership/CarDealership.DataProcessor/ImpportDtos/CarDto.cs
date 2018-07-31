namespace CarDealership.DataProcessor.ImpportDtos
{
using System.Xml.Serialization;

    [XmlType("car")]
   public class CarDto
    {
        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelDistance { get; set; }
    }
}
