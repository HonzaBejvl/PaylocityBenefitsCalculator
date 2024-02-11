using System;
using System.Collections.Generic;
using System.Linq;
using Api.Dtos.Paycheck;
using Api.Model.Models;
using Api.Temporal;

namespace Api.Services.Paychecks;

public interface IPaycheckCalculationRule
{
    decimal CalculateAnnualDeduction(Employee employee);
}

public class BaseBenefitsCostRule : IPaycheckCalculationRule
{
    private const decimal BaseCost = 12000; // $1,000 per month

    public decimal CalculateAnnualDeduction(Employee employee)
    {
        return BaseCost; // Fixed base cost for all employees
    }
}

public class DependentCostRule(IClock clock) : IPaycheckCalculationRule
{
    private const decimal DependentCost = 7200;
    private const decimal OlderDependentExtraCost = 2400;
    
    public decimal CalculateAnnualDeduction(Employee employee)
    {
        decimal totalCost = 0;
        foreach (var dependent in employee.Dependents)
        {
            totalCost += DependentCost;
            // Add extra cost for dependents over 50
            if (dependent.DateOfBirth.AddYears(50) < clock.UtcNow)
            {
                totalCost += OlderDependentExtraCost;
            }
        }
        return totalCost;
    }
}

public class HighEarnerRule : IPaycheckCalculationRule
{
    private const decimal SalaryThreshold = 80000;
    private const decimal AdditionalPercentage = 0.02m; // 2%

    public decimal CalculateAnnualDeduction(Employee employee)
    {
        if (employee.Salary > SalaryThreshold)
        {
            return employee.Salary * AdditionalPercentage;
        }
        return 0;
    }
}

public class PaycheckCalculationService(IEnumerable<IPaycheckCalculationRule> calculationRules)
{
    public Paycheck CalculatePaycheck(Employee employee)
    {
        var annualDeductions = calculationRules.Sum(rule => rule.CalculateAnnualDeduction(employee));

        var paycheck = new Paycheck
        {
            GrossPay = employee.Salary / 26,
            BenefitsDeduction = annualDeductions / 26,
            NetPay = (employee.Salary - annualDeductions) / 26
        };

        return paycheck;
    }
}
