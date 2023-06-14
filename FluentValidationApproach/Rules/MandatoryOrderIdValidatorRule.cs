using FluentValidationApproach.Models;
using FluentValidation;

namespace FluentValidationApproach.Rules;

public class MandatoryOrderIdValidatorRule: AbstractValidator<IOrderId>
{
    public MandatoryOrderIdValidatorRule()
    {
        RuleFor(arg => arg.OrderId)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithErrorCode("MissingField").WithMessage("{PropertyName} missing.")
            .NotEmpty().WithErrorCode("MissingField").WithMessage("{PropertyName} missing.")
            .WithName("orderId");
    }
}
