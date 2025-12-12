namespace SmartRepairApi.Dtos.Repair
{
    public class RepairQueryParameters
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? Search { get; set; }
        public int? ClientId { get; set; }
        public decimal? MinCost { get; set; }
        public decimal? MaxCost { get; set; }

        // createdAt, cost, device
        public string? Sort { get; set; }
    }
}
