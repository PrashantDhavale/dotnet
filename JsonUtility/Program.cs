using ConsoleTables;
using System.Text.Json;

namespace JsonUtility;

public class Program
{
    public static async Task Main()
    {
        var rawPayload = await HelperFunctions.ReadJsonFileAsync("glossary.json");

        var expectedValueKinds = new Dictionary<string, JsonValueKind[]>
        {
            {"glossary/GlossDiv/price",new[]{JsonValueKind.Number} },
            {"glossary/GlossDiv/isForSale",new[]{JsonValueKind.True,JsonValueKind.False} }
        };

        var jsonPaths = HelperFunctions.EvaluateJsonPaths(rawPayload!).ToList();
        HelperFunctions.EnrichJsonPaths(jsonPaths, expectedValueKinds);
        PrintToConsole(jsonPaths);
    }

    private static void PrintToConsole(List<JsonPath> jsonPaths)
    {
        ConsoleTable.From(jsonPaths
            .Select(y => new
            {
                y.Path,
                ExpectedValueKinds = string.Join("|", y.ExpectedValueKinds!.Select(z => z.ToString())),
                ActualValueKind = y.ActualValueKind.ToString(),
                y.Value,
                y.ActualMatchesExpected
            })).Write(Format.MarkDown);

        var consoleColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("|---------------------ERRORS-----------------------");

        ConsoleTable.From(jsonPaths
            .Where(x => x.ActualMatchesExpected == false)
            .Select(y => new
            {
                y.Value,
                y.ErrorMessage
            })).Write(Format.MarkDown);

        Console.WriteLine(" --------------------------------------------------");
        Console.ForegroundColor = consoleColor;
    }
}