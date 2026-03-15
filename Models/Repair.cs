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
        
        public RepairStatus Status { get; set; } = RepairStatus.Pending;

        // Foreign keys
        public int ClientId { get; set; }
        public int? TechnicianId { get; set; }

        // Navigation properties
        public required Client Client { get; set; }
        public Technician? Technician { get; set; }
        public ICollection<RepairHistory> History { get; set; } = new List<RepairHistory>();
    }
}
