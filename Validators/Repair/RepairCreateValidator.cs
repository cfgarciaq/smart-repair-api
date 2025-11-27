using FluentValidation;
using SmartRepairApi.Dtos.Repair;
using SmartRepairApi.Data;
using Microsoft.EntityFrameworkCore;

namespace SmartRepairApi.Validators.Repair
{
    public class RepairCreateValidator : AbstractValidator<RepairCreateDto>
    {
        private readonly AppDbContext _context;

        public RepairCreateValidator(AppDbContext context)
        {
            _context = context;

            // continue validating other rules even if one fails
            ClassLevelCascadeMode = CascadeMode.Continue;

            RuleFor(repair => repair.Device)
                .NotEmpty().WithMessage("Device is required.")
                .MaximumLength(100).WithMessage("Device cannot exceed 100 characters.");

            RuleFor(repair => repair.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(repair => repair.Cost)
                .GreaterThanOrEqualTo(0).WithMessage("Cost must be a non-negative value.");

            // Async validation for foreign key existence
            RuleFor(repair => repair.ClientId)
                .GreaterThan(0).WithMessage("ClientId must be a positive integer.")
                .MustAsync(ClientExistsAsync).WithMessage("Client does not exist.");
        }

        // Async EF Core check for client existence
        private async Task<bool> ClientExistsAsync(int clientId, CancellationToken token)
        {
            return await _context.Clients.AnyAsync(c => c.Id == clientId, token);
        }
    }
}
