using System.ComponentModel.DataAnnotations;

namespace Prod.CarParking.Models
{
    public class QueueNumber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdCard { get; set; }

        [Required]
        public DateTime EntryTime { get; set; }

       
        public DateTime? ExitTime { get; set; }

        public string? CountTime { get; set; }

        public decimal TotalCost { get; set; }
    }
}
