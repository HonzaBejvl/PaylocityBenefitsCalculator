using Api.Dtos.Employee;

namespace Api.Services.Paychecks;

public class HighEarnerRule : IPaycheckCalculationRule
{
    private const decimal SalaryThreshold = 80000;
    private const decimal AdditionalPercentage = 0.02m; // 2%

    public decimal CalculateAnnualDeduction(GetEmployeeDto employee)
    {
        if (employee.Salary > SalaryThreshold)
        {
            return employee.Salary * AdditionalPercentage;
        }
        return 0;
    }
}
