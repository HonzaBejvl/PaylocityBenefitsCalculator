namespace Api.Model.Models;

/// <summary>
/// Enumerates the types of relationships a dependent can have to an employee.
/// </summary>
public enum Relationship
{
    None = 1,
    Spouse = 2,
    DomesticPartner = 3,
    Child = 4
}
