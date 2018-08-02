namespace CarDealership.Models
{
    using System.Collections.Generic;

    public class Car
    {
        public Car()
        {

        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public ICollection<PartCar> CarParts { get; set; } = new List<PartCar>();
    }
}
