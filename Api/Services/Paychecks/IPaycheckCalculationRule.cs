using Api.Dtos.Employee;

namespace Api.Services.Paychecks;

public interface IPaycheckCalculationRule
{
    decimal CalculateAnnualDeduction(GetEmployeeDto employee);
}