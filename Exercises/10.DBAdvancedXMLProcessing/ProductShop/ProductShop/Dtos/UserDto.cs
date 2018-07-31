using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos
{
    [XmlType("user")]
    public class UserDto
    {
        [XmlAttribute(AttributeName = "firstName",Namespace = null)]
        
        public string FirstName { get; set; }

        [XmlAttribute(AttributeName = "lastName")]
        public string LastName { get; set; }

        [XmlAttribute(AttributeName = "age")]
        public string Age { get; set; }
    }
}
