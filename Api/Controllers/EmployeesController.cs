using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Dtos.Employee;
using Api.Dtos.Paycheck;
using Api.Models;
using Api.Services.Employes;
using Api.Services.Paychecks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IPaycheckCalculationService _paycheckCalculationService;

    public EmployeesController(IEmployeeService employeeService, IPaycheckCalculationService paycheckCalculationService)
    {
        _employeeService = employeeService;
        _paycheckCalculationService = paycheckCalculationService;
    }

    [SwaggerOperation(Summary = "Get employee by id")]
    [ProducesResponseType(200, Type = typeof(ApiResponse<GetEmployeeDto>))]
    [ProducesResponseType(404, Type = typeof(ApiResponse<GetEmployeeDto>))]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id, CancellationToken cancellationToken)
    {
        var employee = await _employeeService.GetEmployeeAsync(id, cancellationToken);
        return employee is null
            ? NotFound(new ApiResponse<GetEmployeeDto> { Message = "Employee not found" })
            : Ok(new ApiResponse<GetEmployeeDto> { Data = employee, Success = true });
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [ProducesResponseType(200, Type = typeof(ApiResponse<List<GetEmployeeDto>>))]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll(CancellationToken cancellationToken)
    {
        var employees = await _employeeService.GetAllEmployeesAsync(cancellationToken);
        return Ok(new ApiResponse<List<GetEmployeeDto>> { Data = employees, Success = true });
    }
    
    [SwaggerOperation(Summary = "Get employee's paycheck by id")]
    [ProducesResponseType(200, Type = typeof(ApiResponse<GetPaycheckDto>))]
    [ProducesResponseType(404, Type = typeof(ApiResponse<GetPaycheckDto>))]
    [ProducesResponseType(400)]
    [HttpGet("{id}/paycheck")]
    public async Task<ActionResult<ApiResponse<GetPaycheckDto>>> GetPaycheck(int id, CancellationToken cancellationToken)
    {
        var employee = await _employeeService.GetEmployeeAsync(id, cancellationToken);
        if(employee is null)
        {
            return NotFound(new ApiResponse<GetPaycheckDto> { Message = "Employee not found" });
        }
        
        var paycheck = _paycheckCalculationService.CalculatePaycheck(employee);
        return Ok(new ApiResponse<GetPaycheckDto> { Data = paycheck, Success = true });
    }
}
