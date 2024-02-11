using System;
using System.Collections.Generic;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Services.Paychecks;
using Api.Temporal;
using ApiTests.Tests.Doubles;
using Xunit;

namespace ApiTests.Tests.Services.Paychecks;

public class OlderDependentAdditionalCostRuleTests
{
    private static IClock _clock = new StoppedClock(new DateTime(2024, 12, 2));
    
    [Fact]
    public void CalculateAnnualDeduction_AddsExtraCostForOlderDependents()
    {
        // Given
        var rule = new OlderDependentAdditionalCostRule(_clock);
        var employee = new GetEmployeeDto
        {
            Dependents = new List<GetDependentDto>
            {
                new() { DateOfBirth = _clock.UtcNow.AddYears(-51) }, // Over 50
                new() { DateOfBirth = _clock.UtcNow.AddYears(-55) }, // Over 50
                new() { DateOfBirth = _clock.UtcNow.AddYears(-24) } // Not over 50
            }
        };
        var expectedDeduction = 2400 * 2; // $2,400 extra per older dependent
        
        // When
        var deduction = rule.CalculateAnnualDeduction(employee);
        
        // Then
        Assert.Equal(expectedDeduction, deduction);
    }

    [Fact]
    public void CalculateAnnualDeduction_NoExtraCostForYoungerDependents()
    {

        // Given
        var rule = new OlderDependentAdditionalCostRule(_clock);
        var employee = new GetEmployeeDto
        {
            Dependents = new List<GetDependentDto>
            {
                new() { DateOfBirth = _clock.UtcNow.AddYears(-25) }, // Over 50
                new() { DateOfBirth = _clock.UtcNow.AddYears(-40) }, // Over 50
            }
        };
        
        // When
        var deduction = rule.CalculateAnnualDeduction(employee);
        
        // Then
        Assert.Equal(0, deduction); // No extra cost for dependents under 50
    }
}