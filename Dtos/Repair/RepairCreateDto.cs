namespace SmartRepairApi.Dtos.Repair
{
    public class RepairCreateDto
    {
        public required string Device { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int ClientId { get; set; }
        public int TechnicianId { get; set; }
    }
}
