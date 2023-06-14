using System.Text.Json;
using FluentValidationApproach.Models;
using FluentValidationApproach.Validators; 
using FluentValidationApproach.Factories;

namespace FluentValidationApproach;

public class Program
{
    public static async Task Main()
    {
        var req = new Context() { OrderId = null, OrderLocation = "AUST" };

        var validator = new ValidatorBuilder()
            .WithMandatoryOrderIdValidator()
            .WithOptionalOrderLocationValidator()
            .Build();

        var result = await validator.ValidateAsync(req);

        if (!result.IsValid)
        {
            var vr = ValidationResponseFactory.Create(result.Errors);

            var json = JsonSerializer.Serialize(new { errors = vr },
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });

            Console.WriteLine(json);
        }
        Console.ReadLine();
    }
}