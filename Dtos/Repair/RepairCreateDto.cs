namespace SmartRepairApi.Dtos.Repair
{
    public class RepairCreateDto
    {
        public required string Device { get; set; }
        public required string Description { get; set; }
        public decimal Cost { get; set; }
        public int ClientId { get; set; }
    }
}
