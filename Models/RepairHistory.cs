using SmartRepairApi.Models.Enums;

namespace SmartRepairApi.Models
{
    public class RepairHistory
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public RepairStatus Status { get; set; }
        public required string Notes { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public Repair? Repair { get; set; }
    }
}