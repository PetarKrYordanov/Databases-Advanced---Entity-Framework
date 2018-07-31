namespace ProductShop.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("category")]
    public class CategoryDto
    {
        [MinLength(3), MaxLength(15)]
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
