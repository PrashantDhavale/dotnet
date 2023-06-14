using FluentValidationApproach.Models;
using FluentValidation;

namespace FluentValidationApproach.Rules;

public class OptionalOrderLocationValidatorRule : AbstractValidator<IOrderLocation>
{
    public OptionalOrderLocationValidatorRule()
    {
        RuleFor(arg => arg.OrderLocation)
       .Cascade(CascadeMode.Stop)
       .MaximumLength(3).WithErrorCode("InvalidFieldValue").When(x => !string.IsNullOrWhiteSpace(x.OrderLocation))
       .WithMessage("{PropertyName} must be max 3 characters long.")
       .WithName("orderLocation");
    }
}