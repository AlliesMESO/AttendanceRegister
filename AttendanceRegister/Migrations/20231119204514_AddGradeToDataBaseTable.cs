using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceRegister.Migrations
{
    public partial class AddGradeToDataBaseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "AttendanceRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "AttendanceRecords");
        }
    }
}
