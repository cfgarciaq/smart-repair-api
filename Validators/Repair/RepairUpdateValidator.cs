using FluentValidation;
using SmartRepairApi.Dtos.Repair;

namespace SmartRepairApi.Validators.Repair
{
    public class RepairUpdateValidator : AbstractValidator<RepairUpdateDto>
    {
        public RepairUpdateValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.Cost)
                .GreaterThanOrEqualTo(0);
        }
    }
}
