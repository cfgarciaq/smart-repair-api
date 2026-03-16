using SmartRepairApi.Data;
using SmartRepairApi.Models;
using SmartRepairApi.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace SmartRepairApi.Data.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            // 1. Seed Technicians
            if (!await context.Technicians.AnyAsync())
            {
                var technicians = new List<Technician>
                {
                    new() { Name = "John Doe", Specialization = "Smartphones" },
                    new() { Name = "Jane Smith", Specialization = "Laptops & Tablets" },
                    new() { Name = "Mike Ross", Specialization = "General Electronics" }
                };
                await context.Technicians.AddRangeAsync(technicians);
                await context.SaveChangesAsync();
            }

            // 2. Seed Clients
            if (!await context.Clients.AnyAsync())
            {
                var clients = new List<Client>
                {
                    new() { Name = "Carlos Garcia", Phone = "600111222" },
                    new() { Name = "Ana Lopez", Phone = "600333444" },
                    new() { Name = "John Smith", Phone = "600555666" },
                    new() { Name = "Maria Rodriguez", Phone = "600777888" },
                    new() { Name = "David Johnson", Phone = "600999000" },
                    new() { Name = "Laura Martinez", Phone = "601111222" },
                    new() { Name = "James Brown", Phone = "601333444" },
                };
                await context.Clients.AddRangeAsync(clients);
                await context.SaveChangesAsync();
            }

            // 3. Seed Repairs
            if (!await context.Repairs.AnyAsync())
            {
                var clients = await context.Clients.ToListAsync();
                var technicians = await context.Technicians.ToListAsync();

                var repairs = new List<Repair>
                {
                    new() { 
                        Device = "iPhone 13", 
                        Description = "Battery replacement", 
                        Cost = 80, 
                        ClientId = clients[0].Id, 
                        Client = clients[0],
                        TechnicianId = technicians[0].Id,
                        Status = RepairStatus.Completed
                    },
                    new() { 
                        Device = "Samsung S22", 
                        Description = "Screen broken", 
                        Cost = 120, 
                        ClientId = clients[1].Id, 
                        Client = clients[1],
                        TechnicianId = technicians[0].Id,
                        Status = RepairStatus.InProgress
                    },
                    new() { 
                        Device = "MacBook Pro", 
                        Description = "Keyboard issue", 
                        Cost = 200, 
                        ClientId = clients[2].Id, 
                        Client = clients[2],
                        TechnicianId = technicians[1].Id,
                        Status = RepairStatus.Pending
                    }
                };

                await context.Repairs.AddRangeAsync(repairs);
                await context.SaveChangesAsync();

                // 4. Seed History for the first repair
                var firstRepair = await context.Repairs.FirstAsync();
                var now = DateTime.UtcNow;
                var history = new List<RepairHistory>
                {
                    new() { RepairId = firstRepair.Id, Status = RepairStatus.Pending, Notes = "Initial reception of the device", ChangedAt = now.AddDays(-2) },
                    new() { RepairId = firstRepair.Id, Status = RepairStatus.InProgress, Notes = "Technician started diagnostic and battery replacement", ChangedAt = now.AddDays(-1) },
                    new() { RepairId = firstRepair.Id, Status = RepairStatus.Completed, Notes = "Battery replaced successfully and passed all quality tests", ChangedAt = now }
                };
                await context.RepairHistories.AddRangeAsync(history);
                await context.SaveChangesAsync();
            }
        }
    }
}
