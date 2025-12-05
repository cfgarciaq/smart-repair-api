using FluentValidation;
using SmartRepairApi.Dtos.Client;

namespace SmartRepairApi.Validators.Client
{
    public class ClientCreateValidator : AbstractValidator<ClientCreateDto>
    {
        public ClientCreateValidator()
        {
            RuleFor(client => client.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters.");

            RuleFor(client => client.Phone)
                .NotEmpty()
                .WithMessage("Phone is required.")
                .Matches(@"^[0-9]{9}$")
                .WithMessage("Phone number must be exactly 9 digits.");
        }
    }
}
