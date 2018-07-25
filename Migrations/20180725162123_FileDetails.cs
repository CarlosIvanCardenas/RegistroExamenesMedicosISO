using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenesMedicos.Migrations
{
    public partial class FileDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Files",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Files",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Files");
        }
    }
}
