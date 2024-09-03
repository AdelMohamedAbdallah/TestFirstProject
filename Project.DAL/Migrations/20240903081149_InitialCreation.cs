using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Department_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Department_Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Department_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Fname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Employee_Lname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Employee_Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Employee_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Employee_Salary = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false, defaultValue: 4000.0),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 9, 3, 11, 11, 49, 301, DateTimeKind.Local).AddTicks(369)),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_Id);
                    table.CheckConstraint("CK_Salary", "Employee_Salary between 4000 and 10000");
                    table.ForeignKey(
                        name: "FK_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Departments",
                        principalColumn: "Department_Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Department_Code",
                table: "Departments",
                column: "Department_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Department_Name",
                table: "Departments",
                column: "Department_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Department_Id",
                table: "Employees",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Employee_Email",
                table: "Employees",
                column: "Employee_Email",
                unique: true,
                filter: "[Employee_Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Employee_Phone",
                table: "Employees",
                column: "Employee_Phone",
                unique: true,
                filter: "[Employee_Phone] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
