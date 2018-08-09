using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Stations.Models.Enums;
namespace Stations.Models
{
  public  class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(typeof(decimal),"0.0000000001", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [MaxLength(8)]
        [RegularExpression(@"^[A-Za-z]{2}[0-9]{1,6}$")]
        public string SeatingPlace { get; set; }
        [ForeignKey("Trip")]
        
        public int TripId { get; set; }
        [Required]
        public Trip Trip { get; set; }

        public int? CustomerCardId { get; set; }
        public CustomerCard CustomerCard { get; set; }

    }
}
