using System.Text.Json.Nodes;
using System.Text.Json;

namespace JsonDomParsing;

public class HelperFunctions
{
    public static async Task<string?> ReadJsonFileAsync(string filePath)
    {
        using StreamReader sr = new StreamReader(filePath);
        return await sr.ReadToEndAsync();
    }

    public static IEnumerable<string?> ReadJsonArrayElements(string? rawJson, string? nodePath = "")
    {
        var jsonNode = JsonNode.Parse(rawJson!)!;

        string[] pathNodeNames = nodePath!.Split(".", StringSplitOptions.RemoveEmptyEntries);

        var dataNode = jsonNode.Root;
        foreach (var pathNode in pathNodeNames)
            dataNode = dataNode![pathNode]!;

        var arrayAsStrings = new List<string?>();
        if (dataNode is not null && dataNode is JsonArray)
        {
            foreach (var item in dataNode.AsArray())
            {
                arrayAsStrings.Add(item!.ToJsonString());
            }
            return arrayAsStrings;
        }
        return Enumerable.Empty<string>();
    }

    public static IEnumerable<string?> ReadJsonArray(string? rawJson, string? nodePath = "")
    {
        using (JsonDocument document = JsonDocument.Parse(rawJson!))
        {
            var root = document.RootElement;
            string[] pathNodeNames = nodePath!.Split(".", StringSplitOptions.RemoveEmptyEntries);

            foreach (var pathNode in pathNodeNames)
                root.TryGetProperty(pathNode, out root);

            if (root.ValueKind is JsonValueKind.Array)
            {
                var arrayAsStrings = new List<string?>();
                foreach (JsonElement item in root.EnumerateArray())
                {
                    arrayAsStrings.Add(item.GetRawText());
                }
                return arrayAsStrings;
            }
        }
        return Enumerable.Empty<string>();
    }
}
