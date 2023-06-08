using System.Text.Json;

namespace JsonUtility;

public record JsonPath
{
    public string? Path { get; set; }
    public JsonValueKind[]? ExpectedValueKinds { get; set; }
    public JsonValueKind? ActualValueKind { get; set; }
    public string? Value { get; set; }
    public bool ActualMatchesExpected { get; set; }
    public string? ErrorMessage { get; set; }
}
