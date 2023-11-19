using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceRegister.Migrations
{
    public partial class AddIsPresentToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "AttendanceRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "AttendanceRecords");
        }
    }
}
