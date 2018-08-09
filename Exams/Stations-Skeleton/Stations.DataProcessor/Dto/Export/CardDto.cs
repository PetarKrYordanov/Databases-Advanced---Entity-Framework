using Stations.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Export
{
    [XmlType("Card")]
   public class CardDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("type")]
        public CardType type{ get; set; }

        [XmlArray("Tickets"),XmlArrayItem("Ticket")]
        public List<TicketDto> Tickets { get; set; }
    }
}
