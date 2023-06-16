using FluentValidationApproach.Models;
using FluentValidation;

namespace FluentValidationApproach.Rules;

public class JsonPayloadValidationRule : AbstractValidator<IJsonPayload>
{
    public JsonPayloadValidationRule()
    {
        RuleFor(arg => arg.JsonPayload)
            .Cascade(CascadeMode.Stop)
            .Must(MustBeSafeJson);
    }

    private bool MustBeSafeJson(byte[]? jsonPayload)
    {
        // process - parse - validate the jsonPayload here.
        return true;
    }
}
