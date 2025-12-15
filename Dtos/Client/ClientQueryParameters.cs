namespace SmartRepairApi.Dtos.Client
{
    public class ClientQueryParameters
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? Search { get; set; }

        // name, phone
        public string? Sort { get; set; }
    }
}
