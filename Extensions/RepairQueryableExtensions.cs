using SmartRepairApi.Dtos.Repair;
using SmartRepairApi.Models;

namespace SmartRepairApi.Extensions
{
    public static class RepairQueryableExtensions
    {
        public static IQueryable<Repair> ApplyFiltering(
            this IQueryable<Repair> query, RepairQueryParameters param)
        {
            if (!string.IsNullOrWhiteSpace(param.Search))
            {
                query = query.Where(r =>
                    r.Device.Contains(param.Search) ||
                    r.Description.Contains(param.Search));
            }

            if (param.ClientId.HasValue)
            {
                query = query.Where(r => r.ClientId == param.ClientId);
            }

            if (param.MinCost.HasValue)
            {
                query = query.Where(r => r.Cost >= param.MinCost);
            }

            if (param.MaxCost.HasValue)
            {
                query = query.Where(r => r.Cost <= param.MaxCost);
            }

            return query;
        }

        public static IQueryable<Repair> ApplySorting(
            this IQueryable<Repair> query, string? sort)
        {
            if (string.IsNullOrWhiteSpace(sort))
                return query.OrderByDescending(r => r.CreatedAt);

            return sort.ToLower() switch
            {
                "cost" => query.OrderBy(r => r.Cost),
                "cost_desc" => query.OrderByDescending(r => r.Cost),

                "device" => query.OrderBy(r => r.Device),
                "device_desc" => query.OrderByDescending(r => r.Device),

                "createdat" => query.OrderBy(r => r.CreatedAt),
                "createdat_desc" => query.OrderByDescending(r => r.CreatedAt),

                _ => query.OrderByDescending(r => r.CreatedAt),
            };
        }
    }
}
