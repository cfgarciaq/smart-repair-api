using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRepairApi.Data;
using SmartRepairApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// 3. AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 4. FluentValidation
// Register all validators in the assembly
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Suppress automatic model validation
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Deactivate automatic model state validation
        options.SuppressModelStateInvalidFilter = true;
    });

// ------------------------------------------------------------

// BUILD APP
var app = builder.Build();

// 5. Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Detailed error pages in development
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Enforce HTTPS

app.UseGlobalExceptionMiddleware();
app.UseAuthorization();

// 6. Endpoints
app.MapControllers();

await app.RunAsync();
