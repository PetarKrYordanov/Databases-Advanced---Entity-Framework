using System.Xml.Serialization;

namespace PetClinic.DataProcessor.DtoImport
{
    [XmlRoot("AnimalAid")]
    public class AnimalAidDto
    {
        [XmlElement("Name")]
        public string AnimalAidName { get; set; }
    }
}