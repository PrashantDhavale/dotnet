﻿namespace JsonDomParsing;

public class Program
{
    public static async Task Main()
    {
        var rawPayload1 = await HelperFunctions.ReadJsonFileAsync("sample.json");
        var rawPayload2 = await HelperFunctions.ReadJsonFileAsync("sampleArray.json");

        foreach (var item in HelperFunctions.ReadJsonArrayElements(rawPayload1, "data.balances1"))
        {
            Console.WriteLine($"JSON1={item}");
        }

        foreach (var item in HelperFunctions.ReadJsonArray(rawPayload1, "data.balances1"))
        {
            Console.WriteLine($"JSON2={item}");
        }

        foreach (var item in HelperFunctions.ReadJsonArrayElements(rawPayload2))
        {
            Console.WriteLine($"JSON3={item}");
        }

        foreach (var item in HelperFunctions.ReadJsonArray(rawPayload2))
        {
            Console.WriteLine($"JSON4={item}");
        }
    }
}