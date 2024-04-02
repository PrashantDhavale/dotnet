using PayslipGenerator.Application.Contracts;
using PayslipGenerator.Application.Models;

namespace PayslipGenerator.Application.Services;

public class AnnualTaxCalculationService : ITaxCalculationService
{
    private static readonly TaxSlab[] _taxSlabs = [
        TaxSlab.Create(0, 20000, 0),
        TaxSlab.Create(20001, 40000, 10),
        TaxSlab.Create(40001, 80000, 20),
        TaxSlab.Create(80001, 180000, 30),
        TaxSlab.Create(180001, -1, 40)
    ];

    public double CalculateTax(double salary)
    {
        if (salary <= 0)
        {
            throw new ArgumentException("Invalid annual salary");
        }

        double totalTax = 0;
        foreach (var taxSlab in _taxSlabs)
        {
            var (BalanceSalary, SlabTax) = CalculateSlabTax(taxSlab, salary);
            salary = BalanceSalary;
            totalTax += SlabTax;
            if (salary <= 0)
                break;
        }

        return Math.Floor(totalTax);
    }

    private (double BalanceSalary, double SlabTax) CalculateSlabTax(TaxSlab taxSlab, double salary)
    {
        var taxSlabTo = (taxSlab.To == -1) ? salary : taxSlab.To;
        double bracketDifference = Math.Abs(taxSlab.From - taxSlabTo);
        if (bracketDifference >= salary)
        {
            bracketDifference = salary;
        }
        double slabTax = (bracketDifference * taxSlab.Percentage) / 100;
        double balanceSalary = Math.Abs(salary - bracketDifference);

        return (balanceSalary, slabTax);
    }
}