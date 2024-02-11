using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Model.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmployeeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "Salary", "DateOfBirth" },
                values: new object[,]
                {
                    { 1, "LeBron", "James", 75420.99m, new DateTime(1984, 12, 30) },
                    { 2, "Ja", "Morant", 92365.22m, new DateTime(1999, 8, 10) },
                    { 3, "Michael", "Jordan", 143211.12m, new DateTime(1963, 2, 17) }
                });

            // Seed Dependent Data
            migrationBuilder.InsertData(
                table: "Dependents",
                columns: new[] { "Id", "FirstName", "LastName", "Relationship", "DateOfBirth", "EmployeeId" },
                values: new object[,]
                {
                    { 1, "Spouse", "Morant", 2, new DateTime(1998, 3, 3), 2 },
                    { 2, "Child1", "Morant", 4, new DateTime(2020, 6, 23), 2 },
                    { 3, "Child2", "Morant", 4, new DateTime(2021, 5, 18), 2 },
                    { 4, "DP", "Jordan", 3, new DateTime(1974, 1, 2), 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
