using FluentValidation;
using FluentValidationApproach.Models;
using FluentValidationApproach.Rules;

namespace FluentValidationApproach.Validators;

public class ContextValidator : AbstractValidator<Context> { }

public class ContextValidationBuilder
{
    private readonly ContextValidator _validator = new();

    public ContextValidator Build() => _validator;

    public ContextValidationBuilder WithMandatoryOrderIdValidator()
    {
        _validator.Include(new MandatoryOrderIdValidatorRule());
        return this;
    }

    public ContextValidationBuilder WithOptionalOrderLocationValidator()
    {
        _validator.Include(new OptionalOrderLocationValidatorRule());
        return this;
    }
}
