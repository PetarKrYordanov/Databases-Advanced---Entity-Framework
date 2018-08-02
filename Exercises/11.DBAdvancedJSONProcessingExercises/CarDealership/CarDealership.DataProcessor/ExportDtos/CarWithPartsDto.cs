using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealership.DataProcessor.ExportDtos
{
    [XmlType("car")]
    public class CarWithPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts"), XmlArrayItem("part")]
        public List<PartListDto> Parts { get; set; } = new List<PartListDto>();

    }
}
