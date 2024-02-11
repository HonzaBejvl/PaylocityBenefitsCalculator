using Api.Dtos.Employee;
using Api.Temporal;

namespace Api.Services.Paychecks;

public class OlderDependentAdditionalCostRule(IClock clock) : IPaycheckCalculationRule
{
    private const decimal OlderDependentExtraCost = 2400; // $200 per month for dependents over 50
    private const int AgeThreshold = 50;

    public decimal CalculateAnnualDeduction(GetEmployeeDto employee)
    {
        decimal totalExtraCost = 0;
        foreach (var dependent in employee.Dependents)
        {
            if (dependent.DateOfBirth.AddYears(AgeThreshold) < clock.UtcNow)
            {
                totalExtraCost += OlderDependentExtraCost;
            }
        }
        return totalExtraCost;
    }
}
