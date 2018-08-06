using FastFood.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Order")]
  public  class OrderDto
    {

        [Required]
        [XmlElement("Customer")]
        public string Customer { get; set; }
        [XmlElement("Employee")]
        [Required]
        public string Employee { get; set; }
        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }
       [XmlElement("Type")]
        [Required]
        public string Type{ get; set; }
        [XmlArray("Items"),XmlArrayItem("Item")]
        public List<ItemArrayDto> Items { get; set; } = new List<ItemArrayDto>();
    }
}
