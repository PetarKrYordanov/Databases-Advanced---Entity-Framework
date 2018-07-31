using System.Xml.Serialization;

namespace CarDealership.DataProcessor.ExportDtos
{
    [XmlType("car")]
    public class CarAttributeDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

    }
}