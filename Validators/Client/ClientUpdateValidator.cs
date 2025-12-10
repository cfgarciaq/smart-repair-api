using FluentValidation;
using SmartRepairApi.Dtos.Client;

namespace SmartRepairApi.Validators.Client
{
    public class ClientUpdateValidator : AbstractValidator<ClientUpdateDto>
    {
        public ClientUpdateValidator()
        {
            // Stop validating further rules on the first failure
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches("^[0-9]{9}$").WithMessage("Phone number must be exactly 9 digits.");
        }
    }
}
