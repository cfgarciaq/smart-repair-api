namespace SmartRepairApi.Models
{
    public class Technician
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Repair> Repairs { get; set; } = new List<Repair>();
    }
}