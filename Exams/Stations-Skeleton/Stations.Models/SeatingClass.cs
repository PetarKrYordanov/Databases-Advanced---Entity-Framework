using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.Models
{
  public  class SeatingClass
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [StringLength(2,MinimumLength =2)]
        [Required]
        public string Abbreviation  { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; } = new List<TrainSeat>();


    }
}
