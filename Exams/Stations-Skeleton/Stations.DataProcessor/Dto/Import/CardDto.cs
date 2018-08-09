using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import
{
    [XmlType("Card")]
  public  class CardDto
    {
        [Required]
        [MaxLength(128)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Age")]
        [Range(0, 120)]
        public int Age { get; set; }

        [XmlElement("CardType")]
        public string CardType { get; set; }
    }
}
