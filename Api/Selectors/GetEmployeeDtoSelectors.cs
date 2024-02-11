using System;
using System.Linq;
using System.Linq.Expressions;
using Api.Dtos.Employee;
using Api.Model.Models;

namespace Api.Selectors;

public static class GetEmployeeDtoSelectors
{
    public static readonly Expression<Func<Employee, GetEmployeeDto>> FromEmployee = e => new GetEmployeeDto
    {
        Id = e.Id,
        FirstName = e.FirstName,
        LastName = e.LastName,
        Salary = e.Salary,
        DateOfBirth = e.DateOfBirth,
        Dependents = e.Dependents.Select(d => GetDependentDtoSelectors.FromDependent.Compile().Invoke(d))
    };
}
