namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Enums;
    public class Order
    {
        public Order()
        {
           SetTotalPrice(this.OrderItems);
        }

        private void SetTotalPrice(ICollection<OrderItem> orderItems)
        {
            var ordersItem = orderItems.ToList();
            var price = orderItems
                .Select(e => e.Item.Price * (decimal)e.Quantity).Sum();
            this.TotalPrice = price;
        }

        public int Id { get; set; }
        [Column(TypeName = "text")]
        [Required]
        public string Customer { get; set; }
        [Required]
        public DateTime DateTime{ get; set; }

        
        public OrderType Type{ get; set; }
        [NotMapped]
        public decimal TotalPrice { get; set; }

        public int EmployeeId { get; set; }
        [Required]
        public Employee Employee { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
  
}