using System.Collections.Generic;
using System.Linq;
using Api.Model;
using Api.Selectors;
using System.Threading;
using System.Threading.Tasks;
using Api.Dtos.Dependent;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class DependentService(ApiContext apiContext)
{
    /// <summary>
    /// Retrieves all dependents.
    /// </summary>
    public async Task<List<GetDependentDto>> GetAllDependentAsync(CancellationToken cancellationToken)
    {
        return await apiContext.Dependents
            .Select(GetDependentDtoSelectors.FromDependent)
            .ToListAsync(cancellationToken);
    }

    public async Task<GetDependentDto?> GetDependentAsync(int dependentId, CancellationToken cancellationToken)
    {
        return await apiContext.Dependents
            .Where(d => d.Id == dependentId)
            .Select(GetDependentDtoSelectors.FromDependent)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
