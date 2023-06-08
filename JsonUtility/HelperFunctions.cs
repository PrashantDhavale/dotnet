using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JsonUtility;

public class HelperFunctions
{
    public static async Task<string?> ReadJsonFileAsync(string filePath)
    {
        using StreamReader sr = new StreamReader(filePath);
        return await sr.ReadToEndAsync();
    }

    public static IEnumerable<JsonPath> EvaluateJsonPaths(string rayPayload)
    {
        using var jsonDocument = JsonDocument.Parse(rayPayload, new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip, AllowTrailingCommas = true });
        var rootElement = jsonDocument.RootElement;

        var queue = new Queue<(string ParentPath, JsonElement element)>();

        queue.Enqueue(("", rootElement));
        while (queue.Any())
        {
            var (parentPath, element) = queue.Dequeue();
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    parentPath = parentPath == "" ? parentPath : parentPath + "/";

                    foreach (var nextEl in element.EnumerateObject())
                        queue.Enqueue(($"{parentPath}{nextEl.Name}", nextEl.Value));
                    break;
                case JsonValueKind.Array:
                    foreach (var (nextEl, i) in element.EnumerateArray().Select((jsonElement, i) => (jsonElement, i)))
                        queue.Enqueue(($"{parentPath}[{i}]", nextEl));
                    break;
                case JsonValueKind.Undefined:
                case JsonValueKind.String:
                case JsonValueKind.Number:
                case JsonValueKind.True:
                case JsonValueKind.False:
                case JsonValueKind.Null:
                    yield return new JsonPath
                    {
                        Path = parentPath,
                        ActualValueKind = element.ValueKind,
                        Value = element.GetRawText()
                    };
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public static void EnrichJsonPaths(List<JsonPath> jsonPaths, Dictionary<string, JsonValueKind[]> expectedValueKinds)
    {
        foreach (var jsonPath in jsonPaths.Where(pathInfo => pathInfo.Path != null))
        {
            var key = Regex.Replace(jsonPath.Path!, @"\[[^]]*\]", "");
            expectedValueKinds.TryGetValue(key, out var jsonValueKinds);
            jsonPath.ExpectedValueKinds = jsonValueKinds ?? new[] { JsonValueKind.String };
            jsonPath.ActualMatchesExpected = jsonPath.ExpectedValueKinds.Any(evk => evk == jsonPath.ActualValueKind);
            if (!jsonPath.ActualMatchesExpected)
            {
                jsonPath.ErrorMessage = $@"'{jsonPath.Path}' should be an '{string.Join("|", jsonPath.ExpectedValueKinds!.Select(evk => evk.ToString()))}'";
            }
        }
    }
}