using FluentValidation;
using SmartRepairApi.Dtos.Client;

namespace SmartRepairApi.Validators.Client
{
    public class ClientUpdateValidator : AbstractValidator<ClientUpdateDto>
    {
        public ClientUpdateValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty()
                    .MaximumLength(100);

            RuleFor(x => x.Phone)
                    .NotEmpty()
                    .Matches(@"^[0-9]{9}$");
        }
    }
}
