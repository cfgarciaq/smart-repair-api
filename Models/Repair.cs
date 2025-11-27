using Microsoft.EntityFrameworkCore;

namespace SmartRepairApi.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public required string Device { get; set; }
        public required string Description { get; set; }

        [Precision(18, 2)]
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key
        public int ClientId { get; set; }

        // Navigation property
        public required Client Client { get; set; }
    }
}
