namespace JsonDomParsing;

public class Program
{
    public static async Task Main()
    {
        var rawPayload1 = await HelperFunctions.ReadJsonFileAsync("sample.json");
        var rawPayload2 = await HelperFunctions.ReadJsonFileAsync("sampleArray.json");

        var elements1 = HelperFunctions.ReadJsonArrayElements(rawPayload1, "data.balances");
        foreach (var item in elements1)
        {
            Console.WriteLine($"JSON1={item}");
        }

        var elements2 = HelperFunctions.ReadJsonArray(rawPayload1, "data.balances");
        foreach (var item in elements2)
        {
            Console.WriteLine($"JSON2={item}");
        }

        var elements3 = HelperFunctions.ReadJsonArrayElements(rawPayload2);
        foreach (var item in elements3)
        {
            Console.WriteLine($"JSON3={item}");
        }

        var elements4 = HelperFunctions.ReadJsonArray(rawPayload2);
        foreach (var item in elements4)
        {
            Console.WriteLine($"JSON4={item}");
        }
    }
}