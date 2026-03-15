namespace SmartRepairApi.Models
{
    public enum RepairStatus
    {
        Pending,
        InProgress,
        Completed,
        Delivered,
        Cancelled
    }

    public class RepairHistory
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public RepairStatus Status { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public Repair? Repair { get; set; }
    }
}