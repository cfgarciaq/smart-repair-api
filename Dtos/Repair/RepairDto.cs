using SmartRepairApi.Dtos.Client;

namespace SmartRepairApi.Dtos.Repair
{
    public class RepairDto
    {
        public int Id { get; set; }
        public required string Device { get; set; }
        public required string Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }

        // Nested client DTO
        public required ClientDto Client { get; set; }
    }
}
