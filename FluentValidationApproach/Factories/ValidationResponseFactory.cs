using FluentValidation.Results;
using FluentValidationApproach.Models;

namespace FluentValidationApproach.Factories;

public class ValidationResponseFactory
{
    public static List<ErrorResponse>? Create(List<ValidationFailure> failures)
    {
        var errors = new List<ErrorResponse>();
        foreach (var failure in failures)
        {
            var error = ConstructErrorResponse(failure);
            if (error != null)
                errors.Add(error);

            // Console.WriteLine(failure.ErrorCode + "-:" + failure.ErrorMessage);
        }
        return errors!;
    }

    private static ErrorResponse? ConstructErrorResponse(ValidationFailure failure)
    {
        ErrorResponse? response = failure.ErrorCode switch
        {
            "MissingField" => new("C1") { Title = "Missing field", DetailMessage = failure.ErrorMessage },
            "InvalidFieldValue" => new("C2") { Title = "Invalid field", DetailMessage = failure.ErrorMessage },
            _ => null
        };

        return response;
    }
}