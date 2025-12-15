using SmartRepairApi.Data;
using SmartRepairApi.Models;

namespace SmartRepairApi.Data.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            // Seed Clients if none exist
            if (!context.Clients.Any())
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

                // Add clients to the context and save changes
                await context.Clients.AddRangeAsync(clients);
                await context.SaveChangesAsync();
            }


            if (!context.Repairs.Any())
            {
                // Retrieve clients to associate with repairs
                var clients = context.Clients.ToList();

                // If there are no repairs, we can log or handle it as needed
                var repairs = new List<Repair>
                {
                    new() { Device = "iPhone 13", Description = "Battery replacement", Cost = 80, ClientId = clients[0].Id, Client = clients[0] },
                    new() { Device = "Samsung S22", Description = "Screen broken", Cost = 120, ClientId = clients[1].Id, Client = clients[1] },
                    new() { Device = "Xiaomi Redmi", Description = "Charging port", Cost = 60, ClientId = clients[2].Id, Client = clients[2] },
                    new() { Device = "iPhone X", Description = "Speaker issue", Cost = 50, ClientId = clients[3].Id, Client = clients[3] },
                    new() { Device = "Huawei P30", Description = "Camera not working", Cost = 90, ClientId = clients[4].Id, Client = clients[4] },
                    new() { Device = "OnePlus 9", Description = "Software update", Cost = 40, ClientId = clients[5].Id, Client = clients[5] },
                    new() { Device = "Google Pixel 6", Description = "Microphone issue", Cost = 70, ClientId = clients[6].Id, Client = clients[6] },
                };

                // Add repairs to the context and save changes
                await context.Repairs.AddRangeAsync(repairs);
                await context.SaveChangesAsync();
            }
        }
    }
}
