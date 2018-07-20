using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenesMedicos.Migrations
{
    public partial class AddDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Extension",
                table: "Files",
                newName: "Ficha");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Files",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ficha",
                table: "Files",
                newName: "Extension");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Files",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
