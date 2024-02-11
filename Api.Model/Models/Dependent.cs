using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Models;

/// <summary>
/// Represents a dependent of an employee, such as a spouse, partner, or child.
/// </summary>
public class Dependent
{
    /// <summary>
    /// Gets or sets the unique identifier for the dependent.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the dependent.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the last name of the dependent.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the relationship of the dependent to the employee.
    /// </summary>
    public Relationship Relationship { get; set; }

    /// <summary>
    /// Gets or sets the date of birth of the dependent.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the employee ID this dependent is associated with.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Navigation property for the employee this dependent is associated with.
    /// </summary>
    public Employee Employee { get; set; } = null!;
}
