using System;
using System.Collections.Generic;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Model.Models;
using Api.Services.Paychecks;
using Api.Temporal;
using ApiTests.Tests.Doubles;
using Xunit;

namespace ApiTests.Tests.Services.Paychecks;

public class PaycheckCalculationServiceTests()
{
    private static IClock _clock = new StoppedClock(new DateTime(2024, 12, 2));

    [Fact]
    public void CalculatePaycheck_UsesAllRules()
    {
        // Given
        var employee = new GetEmployeeDto
        {
            Salary = 100000,
            Dependents = new List<GetDependentDto>
            {
                new() { Relationship =  Relationship.Spouse, DateOfBirth = _clock.UtcNow.AddYears(-51) },
                new() { Relationship =  Relationship.Child, DateOfBirth = _clock.UtcNow.AddYears(-8) },
            }
        };
        var rules = new List<IPaycheckCalculationRule>
        {
            new BaseBenefitsCostRule(),
            new HighEarnerRule(),
            new OlderDependentAdditionalCostRule(_clock),
            new DependentCostRule()
        };
        var paycheckService = new PaycheckCalculationService(rules);
        
        // When
        var paycheck = paycheckService.CalculatePaycheck(employee);
        
        // Then
        var grossYearlySalary = employee.Salary;
        var baseBenefitsCost = 1000 * 12;
        var highEarnerCost = grossYearlySalary * 0.02m;
        var olderDependentCost = 200 * 12;
        var dependentCost = 600 * 12 * 2;
        var benefitsCostYearly = baseBenefitsCost + highEarnerCost + olderDependentCost + dependentCost;
        var netYearlySalary = grossYearlySalary - benefitsCostYearly;

        Assert.Equal(grossYearlySalary / 26, paycheck.GrossPay);
        Assert.Equal(benefitsCostYearly / 26, paycheck.BenefitsDeduction);
        Assert.Equal(netYearlySalary / 26, paycheck.NetPay);
    }
    
    [Fact]
    public void ThrowsException_WhenEmployeeHasMultipleSpouses()
    {
        // Given
        var employee = new GetEmployeeDto
        {
            Dependents = new List<GetDependentDto>
            {
                new() { Relationship =  Relationship.Spouse },
                new() { Relationship =  Relationship.Spouse }
            }
        };
        var rules = new List<IPaycheckCalculationRule>();
        var paycheckService = new PaycheckCalculationService(rules);
        
        // When
        var exception = Record.Exception(() => paycheckService.CalculatePaycheck(employee));
        
        // Then
        Assert.NotNull(exception);
        Assert.IsType<Exception>(exception);
    }
    
    [Fact]
    public void ThrowsException_WhenEmployeeHasSpouseAndPartner()
    {
        // Given
        var employee = new GetEmployeeDto
        {
            Dependents = new List<GetDependentDto>
            {
                new() { Relationship =  Relationship.Spouse },
                new() { Relationship =  Relationship.DomesticPartner }
            }
        };
        var rules = new List<IPaycheckCalculationRule>();
        var paycheckService = new PaycheckCalculationService(rules);
        
        // When
        var exception = Record.Exception(() => paycheckService.CalculatePaycheck(employee));
        
        // Then
        Assert.NotNull(exception);
        Assert.IsType<Exception>(exception);
    }
}
