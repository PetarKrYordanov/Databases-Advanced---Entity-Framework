using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
       [XmlType("Item")]
  //  [XmlRoot("Items")]
    public class ItemArrayDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }
}