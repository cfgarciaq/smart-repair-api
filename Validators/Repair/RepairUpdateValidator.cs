using FluentValidation;
using SmartRepairApi.Dtos.Repair;

namespace SmartRepairApi.Validators.Repair
{
    public class RepairUpdateValidator : AbstractValidator<RepairUpdateDto>
    {
        public RepairUpdateValidator()
        {
            // Stop validating further rules on the first failure
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Cost)
                .GreaterThanOrEqualTo(0).WithMessage("Cost must be a non-negative value.");
        }
    }
}
