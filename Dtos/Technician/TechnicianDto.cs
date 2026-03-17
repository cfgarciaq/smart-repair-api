namespace SmartRepairApi.Dtos.Technician
{
    public class TechnicianDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Specialization { get; set; }
    }
}
