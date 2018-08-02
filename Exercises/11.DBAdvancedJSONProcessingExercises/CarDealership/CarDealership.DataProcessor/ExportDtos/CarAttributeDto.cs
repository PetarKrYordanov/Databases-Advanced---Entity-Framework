using System.Xml.Serialization;

namespace CarDealership.DataProcessor.ExportDtos
{
    public class CarAttributeDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

    }
}