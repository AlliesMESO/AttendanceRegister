using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceRegister.Migrations
{
    public partial class AddStudentNameToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "AttendanceRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "AttendanceRecords");
        }
    }
}
