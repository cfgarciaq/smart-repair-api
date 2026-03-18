using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRepairApi.Data;
using SmartRepairApi.Data.Seed;
using SmartRepairApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// 3. AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 4. FluentValidation
// Register all validators in the assembly
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Suppress automatic model validation
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        // Deactivate automatic model state validation
        options.SuppressModelStateInvalidFilter = true;
    });

// CORS Policy for Frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
        policy.WithOrigins("https://smart-repair-ui.vercel.app", "http://localhost:5173") // Allow production and local development
              .AllowAnyHeader()
              .AllowAnyMethod()
    );
});

// ------------------------------------------------------------

// BUILD APP
var app = builder.Build();

// Seed Database on Startup
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope(); // Create a new scope
    var services = scope.ServiceProvider; // Get service provider from scope
    var context = services.GetRequiredService<AppDbContext>(); // Get AppDbContext instance
    await DbSeeder.SeedAsync(context); // Seed the database
}

// 5. Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Detailed error pages in development
}

app.UseSwagger(); // Enable Swagger middleware
app.UseSwaggerUI(); // Enable Swagger UI

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection(); // Enforce HTTPS only in non-production
}

// Use CORS policy
app.UseCors("FrontendPolicy");

// Global Exception Handling Middleware
app.UseGlobalExceptionMiddleware();

// Authorization Middleware
app.UseAuthorization();

// 6. Endpoints
app.MapControllers();

await app.RunAsync();
