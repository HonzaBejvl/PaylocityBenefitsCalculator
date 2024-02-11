using Api.Dtos.Employee;
using Api.Services.Paychecks;
using Xunit;

namespace ApiTests.Tests.Services.Paychecks;

public class BaseBenefitsCostRuleTests
{
    [Fact]
    public void CalculateAnnualDeduction_ReturnsFixedBaseCost()
    {
        // Given
        var rule = new BaseBenefitsCostRule();
        var employee = new GetEmployeeDto(); // Details are not relevant for this rule
        
        // When
        var deduction = rule.CalculateAnnualDeduction(employee);
        
        // Then
        Assert.Equal(12000, deduction);
    }
}
