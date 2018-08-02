﻿namespace CarDealership.Models
{
    public class Sale
    {
        public Sale()
        {

        }
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer{ get; set; }
        public decimal Discount { get; set; }
    }
}