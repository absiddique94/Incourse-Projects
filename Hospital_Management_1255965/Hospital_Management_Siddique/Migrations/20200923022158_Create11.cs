using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management_Siddique.Migrations
{
    public partial class Create11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "DoctorPatients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DoctorPatients",
                nullable: false,
                defaultValue: 0);
        }
    }
}
