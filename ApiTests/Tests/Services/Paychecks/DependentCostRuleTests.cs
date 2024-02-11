using System;
using System.Collections.Generic;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Services.Paychecks;
using Xunit;

namespace ApiTests.Tests.Services.Paychecks;

public class DependentCostRuleTests
{
    [Fact]
    public void CalculateAnnualDeduction_ReturnsCorrectCostForDependents()
    {
        // Given
        var rule = new DependentCostRule();
        var employee = new GetEmployeeDto
        {
            Dependents = new List<GetDependentDto>
            {
                new() { DateOfBirth = DateTime.Now.AddYears(-30) },
                new() { DateOfBirth = DateTime.Now.AddYears(-60) }
            }
        };
        var expectedDeduction = 7200 * 2; // $7,200 per dependent
        
        // When
        var deduction = rule.CalculateAnnualDeduction(employee);
        
        // Assert
        Assert.Equal(expectedDeduction, deduction);
    }

    [Fact]
    public void CalculateAnnualDeduction_ReturnsZeroForNoDependents()
    {
        // Given
        var rule = new DependentCostRule();
        var employee = new GetEmployeeDto(); // No dependents
        
        // When
        var deduction = rule.CalculateAnnualDeduction(employee);
        
        // Then
        Assert.Equal(0, deduction); // Expect $0 deduction for no dependents
    }
}
