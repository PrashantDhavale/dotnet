using FluentAssertions;
using PayslipGenerator.Application.Services;

namespace PayslipGenerator.Application.UnitTests
{
    public class AnnualTaxCalculationServiceTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(0)]
        [InlineData(null)]
        public void CalculateTax_Should_Accept_GreaterThanZeroValue(double annualSalary)
        {
            // Arrange
            var sut = new AnnualTaxCalculationService();
            // Act
            var act = () => sut.CalculateTax(annualSalary);
            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("Invalid annual salary");
        }

        [Theory]
        [InlineData(500)]
        [InlineData(5000)]
        [InlineData(10000)]
        [InlineData(19000)]
        [InlineData(20000)]
        public void CalculateTax_Should_Return_0Tax_When_AnnualSalary_IsLessThanOrEqualTo20000(double annualSalary)
        {
            // Arrange
            var sut = new AnnualTaxCalculationService();
            // Act
            var result = sut.CalculateTax(annualSalary);
            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void CalculateTax_Should_Return_6000Tax_When_AnnualSalary_IsEqualTo60000()
        {
            // Arrange
            var sut = new AnnualTaxCalculationService();
            // Act
            var result = sut.CalculateTax(60000);
            // Assert
            result.Should().Be(6000);
        }

        [Theory]
        [InlineData(500, 0)]
        [InlineData(5000, 0)]
        [InlineData(60000, 6000)]
        [InlineData(100000, 16000)]
        public void CalculateTax_Should_Match_ExpectedAnnualTax(double annualSalary, double expectedAnnualTax)
        {
            // Arrange
            var sut = new AnnualTaxCalculationService();
            // Act
            var result = sut.CalculateTax(annualSalary);
            // Assert
            result.Should().Be(expectedAnnualTax);
        }
    }
}