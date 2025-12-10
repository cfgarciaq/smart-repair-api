namespace SmartRepairApi.Dtos.Repair
{
    public class RepairUpdateDto
    {
        public required string Description { get; set; }
        public required decimal Cost { get; set; }
    }
}
