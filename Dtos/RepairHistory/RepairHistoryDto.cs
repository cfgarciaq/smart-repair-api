namespace SmartRepairApi.Dtos.RepairHistory
{
    public class RepairHistoryDto
    {
        public int Id { get; set; }
        public required string Status { get; set; }
        public string? Notes { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
