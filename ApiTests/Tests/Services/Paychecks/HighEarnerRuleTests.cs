using Api.Dtos.Employee;
using Api.Services.Paychecks;
using Xunit;

namespace ApiTests.Tests.Services.Paychecks;

public class HighEarnerRuleTests
{
    [Fact]
    public void CalculateAnnualDeduction_AppliesExtraCostForHighEarners()
    {
        // Given
        var rule = new HighEarnerRule();
        var highEarner = new GetEmployeeDto { Salary = 85000 }; // Over the threshold
        var expectedDeduction = 85000 * 0.02m; // 2% of 85,000
        
        // When
        var deduction = rule.CalculateAnnualDeduction(highEarner);
        
        // Then
        Assert.Equal(expectedDeduction, deduction);
    }

    [Fact]
    public void CalculateAnnualDeduction_NoExtraCostForNonHighEarners()
    {
        // Given
        var rule = new HighEarnerRule();
        var nonHighEarner = new GetEmployeeDto { Salary = 75000 }; // Below the threshold
        
        // When
        var deduction = rule.CalculateAnnualDeduction(nonHighEarner);
        
        // Then
        Assert.Equal(0, deduction);
    }
}