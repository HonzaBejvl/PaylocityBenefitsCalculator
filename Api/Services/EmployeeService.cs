using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Dtos.Employee;
using Api.Model;
using Api.Selectors;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class EmployeeService(ApiContext apiContext)
{
    /// <summary>
    /// Retrieves all employees with their dependents.
    /// </summary>
    public async Task<List<GetEmployeeDto>> GetAllEmployeesAsync(CancellationToken cancellationToken)
    {
        return await apiContext.Employees
            .Select(GetEmployeeDtoSelectors.FromEmployee)
            .ToListAsync(cancellationToken);
    }

    public async Task<GetEmployeeDto?> GetEmployeeAsync(int employeeId, CancellationToken cancellationToken)
    {
        return await apiContext.Employees
            .Where(e => e.Id == employeeId)
            .Select(GetEmployeeDtoSelectors.FromEmployee)
            .FirstOrDefaultAsync(cancellationToken);
    }

}
