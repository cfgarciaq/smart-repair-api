namespace SmartRepairApi.Dtos.Repair
{
    public class RepairUpdateDto
    {
        // Explicit ID to ensure we are updating the correct resource
        public int Id { get; set; }

        public required string Description { get; set; }
        
        public required decimal Cost { get; set; }

        // Added Status to allow workflow transitions (e.g., Pending -> Completed)
        public required string Status { get; set; }
    }
}
