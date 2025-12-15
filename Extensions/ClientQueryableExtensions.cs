using SmartRepairApi.Dtos.Client;
using SmartRepairApi.Models;

namespace SmartRepairApi.Extensions
{
    public static class ClientQueryableExtensions
    {
        public static IQueryable<Client> ApplyFiltering(
            this IQueryable<Client> query, ClientQueryParameters param)
        {
            if (!string.IsNullOrWhiteSpace(param.Search))
            {
                query = query.Where(c =>
                    c.Name.Contains(param.Search) ||
                    c.Phone.Contains(param.Search));
            }

            return query;
        }

        public static IQueryable<Client> ApplySorting(
            this IQueryable<Client> query, string? sort)
        {
            if (string.IsNullOrWhiteSpace(sort))
                return query.OrderBy(c => c.Name);

            return sort.ToLower() switch
            {
                "name" => query.OrderBy(c => c.Name),
                "name_desc" => query.OrderByDescending(c => c.Name),

                "phone" => query.OrderBy(c => c.Phone),
                "phone_desc" => query.OrderByDescending(c => c.Phone),

                _ => query.OrderBy(c => c.Name)
            };
        }
    }
}
