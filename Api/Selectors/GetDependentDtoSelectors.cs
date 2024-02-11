using System;
using System.Linq.Expressions;
using Api.Dtos.Dependent;
using Api.Model.Models;

namespace Api.Selectors;

public static class GetDependentDtoSelectors
{
    public static readonly Expression<Func<Dependent, GetDependentDto>> FromDependent = d => new GetDependentDto
    {
        Id = d.Id,
        FirstName = d.FirstName,
        LastName = d.LastName,
        DateOfBirth = d.DateOfBirth,
        Relationship = d.Relationship
    };
}