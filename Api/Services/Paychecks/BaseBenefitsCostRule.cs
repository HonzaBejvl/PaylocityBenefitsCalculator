using Api.Dtos.Employee;

namespace Api.Services.Paychecks;

public class BaseBenefitsCostRule : IPaycheckCalculationRule
{
    private const decimal BaseCost = 12000; // $1,000 per month

    public decimal CalculateAnnualDeduction(GetEmployeeDto employee)
    {
        return BaseCost; // Fixed base cost for all employees
    }
}
