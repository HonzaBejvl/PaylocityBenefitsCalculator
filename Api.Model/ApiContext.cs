using Api.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Model;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Dependent> Dependents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
