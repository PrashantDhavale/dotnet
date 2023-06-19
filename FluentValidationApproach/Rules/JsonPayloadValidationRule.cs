using FluentValidationApproach.Models;
using FluentValidation;
using System.Text.Json;

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
        var reader = new Utf8JsonReader(jsonPayload);
        reader.Read();
        reader.Skip();
        return true;
    }
}
