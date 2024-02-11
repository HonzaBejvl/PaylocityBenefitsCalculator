using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Dtos.Dependent;

namespace Api.Services.Dependents;

public interface IDependentService
{
    /// <summary>
    /// Retrieves all dependents.
    /// </summary>
    Task<List<GetDependentDto>> GetAllDependentAsync(CancellationToken cancellationToken);

    Task<GetDependentDto?> GetDependentAsync(int dependentId, CancellationToken cancellationToken);
}
