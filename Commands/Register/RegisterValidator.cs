using FluentValidation;
namespace CarWorkshopAPI.Commands.Register;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Dto.Password)
            .NotEmpty().WithMessage("Password is required")
            .Matches(@"[A-Z]").WithMessage("Password must contain 1 uppercase character")
            .Matches(@"[0-9]").WithMessage("Password must contain 1 digit");
    }
}