using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Stations.Models.Enums;

namespace Stations.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OriginStationId { get; set; }
        [Required]
        public Station OriginStation { get; set; }
        public int DestinationStationId { get; set; }

        [Required]
        public Station DestinationStation { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        [ForeignKey("Train")]
        public int TrainId { get; set; }
        [Required]
        public Train Train { get; set; }
        public TripSatus Status { get; set; } = TripSatus.OnTime;

        public TimeSpan? TimeDifference { get; set; }
    }
}
