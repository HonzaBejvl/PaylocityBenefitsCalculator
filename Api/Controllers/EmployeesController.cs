using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Dtos.Employee;
using Api.Models;
using Api.Services;
using Api.Services.Employes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id, CancellationToken cancellationToken)
    {
        var employee = await _employeeService.GetEmployeeAsync(id, cancellationToken);
        return employee is null
            ? NotFound(new ApiResponse<GetEmployeeDto> { Message = "Employee not found" })
            : Ok(new ApiResponse<GetEmployeeDto> { Data = employee, Success = true });
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll(CancellationToken cancellationToken)
    {
        var employees = await _employeeService.GetAllEmployeesAsync(cancellationToken);
        return Ok(new ApiResponse<List<GetEmployeeDto>> { Data = employees, Success = true });
    }
}
