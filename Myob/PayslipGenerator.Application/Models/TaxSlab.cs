namespace PayslipGenerator.Application.Models;

public record TaxSlab(double From, double To, float Percentage)
{
    public static TaxSlab Create(double from, double to, float percentage)
    {
        return new TaxSlab(from, to, percentage);
    }
}