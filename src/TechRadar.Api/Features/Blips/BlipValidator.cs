using FluentValidation;

namespace TechRadar.Api.Features
{
    public class BlipValidator: AbstractValidator<BlipDto> {
        public BlipValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
