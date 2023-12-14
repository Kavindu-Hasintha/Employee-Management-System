using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewCrud.Migrations
{
    public partial class DepartmentIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateofjoining",
                table: "Employees",
                newName: "DateOfJoin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfJoin",
                table: "Employees",
                newName: "dateofjoining");
        }
    }
}
