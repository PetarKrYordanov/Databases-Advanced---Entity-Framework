using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
    [XmlRoot("Card")]
    public class TicketCardDto
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}