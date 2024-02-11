using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Dtos.Dependent;
using Api.Models;
using Api.Services;
using Api.Services.Dependents;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController : ControllerBase
{
    private readonly IDependentService _dependentService;

    public DependentsController(IDependentService dependentService)
    {
        _dependentService = dependentService;
    }

    [SwaggerOperation(Summary = "Get dependent by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetDependentDto>>> Get(int id, CancellationToken cancellationToken)
    {
        var dependent = await _dependentService.GetDependentAsync(id, cancellationToken);
        return dependent is null
            ? NotFound(new ApiResponse<GetDependentDto> { Message = "Dependent not found" })
            : Ok(new ApiResponse<GetDependentDto> { Data = dependent, Success = true });
    }

    [SwaggerOperation(Summary = "Get all dependents")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll(CancellationToken cancellationToken)
    {
        var dependents = await _dependentService.GetAllDependentAsync(cancellationToken);
        return Ok(new ApiResponse<List<GetDependentDto>> { Data = dependents, Success = true });
    }
}
