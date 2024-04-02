namespace PayslipGenerator.Application.Models;

public record Payslip(string Name, double AnnualSalary, double AnnualIncomeTax)
{
    private const int MonthsInAYear = 12;

    private double GrossMonthlyIncome { get { return AnnualSalary / MonthsInAYear; } }
    private double MonthlyIncomeTax { get { return AnnualIncomeTax / MonthsInAYear; } }
    private double NetMonthlyIncome { get { return (AnnualSalary - AnnualIncomeTax) / MonthsInAYear; } }

    public static Payslip Create(string Name, double AnnualSalary, double AnnualIncomeTax)
    {
        return new Payslip(Name, AnnualSalary, AnnualIncomeTax);
    }

    public override string ToString()
    {
        string payslipOutput = $$"""
            Monthly Payslip for: "{{Name}}"
            Gross Monthly Income: ${{GrossMonthlyIncome:#}}
            Monthly Income Tax: ${{MonthlyIncomeTax:#}}
            Net Monthly Income: ${{NetMonthlyIncome:#}}
            """;

        return payslipOutput;
    }
}