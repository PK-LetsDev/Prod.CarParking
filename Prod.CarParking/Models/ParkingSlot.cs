using System.ComponentModel.DataAnnotations;

namespace Prod.CarParking.Models
{
    public class ParkingSlot
    {
        [Key]
        public int Id { get; set; }

        public string SlotNumber { get; set; }

        public bool IsOccupied { get; set; }
    }
}
