using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Models;

/// <summary>
/// Represents an employee with personal information, salary, and dependents.
/// </summary>
public class Employee
{
    /// <summary>
    /// Gets or sets the unique identifier for the employee.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the employee.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the last name of the employee.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the salary of the employee.
    /// </summary>
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }

    /// <summary>
    /// Gets or sets the date of birth of the employee.
    /// </summary>
    public DateTime DateOfBirth { get; set; }
    
    /// <summary>
    /// Navigation property for the children of the employee.
    /// </summary>
    public List<Dependent> Dependents { get; set; } = new();
}