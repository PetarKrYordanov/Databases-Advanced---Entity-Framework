using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
    [XmlType("Ticket")]
   public class TicketDto
    {
        [XmlAttribute("price")]
        [Required]
        [Range(typeof(decimal), "0.0000000001", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [XmlAttribute("seat")]
        [Required]
        [MaxLength(8)]
        [RegularExpression(@"^[A-Za-z]{2}[0-9]{1,6}$")]
        public string Seat { get; set; }
                
        [XmlElement("Trip")]
        public TicketTripDto Trip { get; set; }

        [XmlElement("Card")]
        public TicketCardDto Card { get; set; } = new TicketCardDto();
    }
}
