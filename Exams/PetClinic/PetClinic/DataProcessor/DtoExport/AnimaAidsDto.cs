using System.Xml.Serialization;

namespace PetClinic.DataProcessor.DtoExport
{
    [XmlRoot("AnimalAids")]
    public class AnimaAidsDto
    {
        [XmlElement("Name")]
        public string AnimalAidName { get; set; }
        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}