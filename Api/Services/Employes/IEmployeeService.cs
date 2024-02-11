using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Dtos.Employee;

namespace Api.Services.Employes;

public interface IEmployeeService
{
    /// <summary>
    /// Retrieves all employees with their dependents.
    /// </summary>
    Task<List<GetEmployeeDto>> GetAllEmployeesAsync(CancellationToken cancellationToken);

    Task<GetEmployeeDto?> GetEmployeeAsync(int employeeId, CancellationToken cancellationToken);
}
