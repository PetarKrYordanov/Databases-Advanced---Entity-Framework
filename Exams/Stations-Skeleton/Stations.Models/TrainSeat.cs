using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stations.Models
{
    public class TrainSeat
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Train")]
        public int TrainId { get; set; }
        [Required]
        public Train Train{ get; set; }
        [ForeignKey("SeatingClass")]
        public int SeatingClassId { get; set; }
        [Required]
        public SeatingClass  SeatingClass { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
    }
}