namespace PayslipGenerator.Application.Contracts;

public interface ITaxCalculationService
{
    public double CalculateTax(double salary);
}
