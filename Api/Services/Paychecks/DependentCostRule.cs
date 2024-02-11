using System.Linq;
using Api.Dtos.Employee;

namespace Api.Services.Paychecks;

public class DependentCostRule : IPaycheckCalculationRule
{
    private const decimal DependentCost = 7200; // $600 per month

    public decimal CalculateAnnualDeduction(GetEmployeeDto employee)
    {
        return employee.Dependents.Count() * DependentCost;
    }
}