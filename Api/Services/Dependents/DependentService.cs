using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Dtos.Dependent;
using Api.Model;
using Api.Selectors;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Dependents;

public class DependentService(ApiContext apiContext) : IDependentService
{
    /// <inheritdoc />
    public async Task<List<GetDependentDto>> GetAllDependentAsync(CancellationToken cancellationToken)
    {
        return await apiContext.Dependents
            .Select(GetDependentDtoSelectors.FromDependent)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<GetDependentDto?> GetDependentAsync(int dependentId, CancellationToken cancellationToken)
    {
        return await apiContext.Dependents
            .Where(d => d.Id == dependentId)
            .Select(GetDependentDtoSelectors.FromDependent)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
