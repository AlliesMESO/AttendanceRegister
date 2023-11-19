using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceRegister.Migrations
{
    public partial class AddClassNameToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "AttendanceRecords",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "AttendanceRecords");
        }
    }
}
