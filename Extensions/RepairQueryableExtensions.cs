using SmartRepairApi.Dtos.Repair;
using SmartRepairApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartRepairApi.Extensions
{
    public static class RepairQueryableExtensions
    {
        public static IQueryable<Repair> ApplyFiltering(
            this IQueryable<Repair> query, RepairQueryParameters param)
        {
            if (!string.IsNullOrWhiteSpace(param.Search))
            {
                var search = param.Search.ToLower();
                query = query.Where(r =>
                    r.Device.ToLower().Contains(search) ||
                    r.Description.ToLower().Contains(search) ||
                    (r.Client != null && r.Client.Name.ToLower().Contains(search)) ||
                    (r.Technician != null && r.Technician.Name.ToLower().Contains(search)));
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

                "client" => query.OrderBy(r => r.Client != null ? r.Client.Name : string.Empty),
                "client_desc" => query.OrderByDescending(r => r.Client != null ? r.Client.Name : string.Empty),

                "technician" => query.OrderBy(r => r.Technician != null ? r.Technician.Name : string.Empty),
                "technician_desc" => query.OrderByDescending(r => r.Technician != null ? r.Technician.Name : string.Empty),

                _ => query.OrderByDescending(r => r.CreatedAt),
            };
        }
    }
}
