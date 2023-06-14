namespace FluentValidationApproach.Models;

public class ErrorResponse
{
    public ErrorResponse(string code)
    {
        Code = code;
    }

    public string? Code { get; set; }
    public string? Title { get; set; }
    public string? DetailMessage { get; set; }
}
