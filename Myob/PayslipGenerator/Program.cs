using PayslipGenerator.Application.Contracts;
using PayslipGenerator.Application.Models;
using PayslipGenerator.Application.Services;

public class Program
{
    private static void Main(string[] args)
    {
        ITaxCalculationService taxCalculationService = new AnnualTaxCalculationService();

        var annualTax = taxCalculationService.CalculateTax(60000);

        var payslip = Payslip.Create("Mary Song", 60000, annualTax);

        Console.WriteLine(payslip);
    }
}
