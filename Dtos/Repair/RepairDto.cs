using SmartRepairApi.Dtos.Client;
using SmartRepairApi.Dtos.Technician;
using SmartRepairApi.Dtos.RepairHistory;

namespace SmartRepairApi.Dtos.Repair
{
    public class RepairDto
    {
        public int Id { get; set; }
        public required string Device { get; set; }
        public required string Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Status { get; set; }

        // Nested client DTO
        public required ClientDto Client { get; set; }

        // Technician DTO
        public TechnicianDto? Technician { get; set; }

        // History collection
        public ICollection<RepairHistoryDto> History { get; set; } = new List<RepairHistoryDto>();
    }
}
