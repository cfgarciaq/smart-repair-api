using SmartRepairApi.Dtos.Client;

namespace SmartRepairApi.Dtos.Repair
{
    public class RepairDto
    {
        public int Id { get; set; }
        public string Device { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }

        // Nested client DTO
        public ClientDto Client { get; set; }
    }
}
