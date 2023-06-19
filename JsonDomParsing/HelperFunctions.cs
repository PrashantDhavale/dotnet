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
        var baseNode = JsonNode.Parse(rawJson!)!;

        var nodeNames = nodePath!.Split(".", StringSplitOptions.RemoveEmptyEntries);

        var node = baseNode.Root;
        foreach (var pathNode in nodeNames)
        {
            var tmpNode = node![pathNode]!;
            if (tmpNode is null)
                break;
            node = tmpNode;
        }

        var arrayElements = new List<string?>();
        if (node is null || node is not JsonArray)
            return Enumerable.Empty<string>();
        
        foreach (var item in node.AsArray())
            arrayElements.Add(item!.ToJsonString());
        
        return arrayElements;
    }

    public static IEnumerable<string?> ReadJsonArray(string? rawJson, string? nodePath = "")
    {
        using (var document = JsonDocument.Parse(rawJson!))
        {
            var element = document.RootElement;
            var nodeNames = nodePath!.Split(".", StringSplitOptions.RemoveEmptyEntries);
            foreach (var nodeName in nodeNames)
            {
                if (element.ValueKind is JsonValueKind.Undefined || !element.TryGetProperty(nodeName, out element))
                    break;
            }

            if (element.ValueKind is JsonValueKind.Array)
            {
                var arrayElements = new List<string?>();
                foreach (JsonElement item in element.EnumerateArray())
                {
                    arrayElements.Add(item.GetRawText());
                }
                return arrayElements;
            }
        }
        return Enumerable.Empty<string>();
    }
}
