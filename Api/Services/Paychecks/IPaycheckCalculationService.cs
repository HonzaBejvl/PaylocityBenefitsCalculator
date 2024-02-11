using Api.Dtos.Employee;
using Api.Dtos.Paycheck;
using Api.Model.Models;

namespace Api.Services.Paychecks;

public interface IPaycheckCalculationService
{
    GetPaycheckDto CalculatePaycheck(GetEmployeeDto employee);
}
