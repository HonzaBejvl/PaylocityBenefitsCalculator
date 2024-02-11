using System;
using System.Collections.Generic;
using System.Linq;
using Api.Dtos.Employee;
using Api.Dtos.Paycheck;
using Api.Model.Models;

namespace Api.Services.Paychecks;

public class PaycheckCalculationService(IEnumerable<IPaycheckCalculationRule> calculationRules) : IPaycheckCalculationService
{
    public GetPaycheckDto CalculatePaycheck(GetEmployeeDto employee)
    {
        ValidateEmployee(employee);
        var annualDeductions = calculationRules.Sum(rule => rule.CalculateAnnualDeduction(employee));

        var paycheck = new GetPaycheckDto
        {
            GrossPay = employee.Salary / 26,
            BenefitsDeduction = annualDeductions / 26,
            NetPay = (employee.Salary - annualDeductions) / 26
        };

        return paycheck;
    }

    private void ValidateEmployee(GetEmployeeDto employee)
    {
        // This should never happen, but just in case
        if(employee.Dependents.Count(e => e.Relationship is Relationship.Spouse or Relationship.DomesticPartner) > 1)
        {
            throw new Exception("Employee cannot have more than one spouse or domestic partner");
        }
    }
}
